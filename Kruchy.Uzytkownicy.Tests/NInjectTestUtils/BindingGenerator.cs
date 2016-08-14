using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ninject.Extensions.Conventions.BindingGenerators;
using Ninject.Syntax;

namespace Kruchy.Uzytkownicy.Tests.NInjectTestUtils
{
    class BindingGenerator : IBindingGenerator
    {
        private const string RegexMatchingValidatorType =
            @"^(?<name>[a-zA-Z]+)Validator$";
        private const string RegexMatchingSimpleType = @"^(?<name>[a-zA-Z]+)$";
        private static readonly Regex ValidatorMatcher =
            new Regex(RegexMatchingValidatorType);
        private static readonly Regex SimpleTypeMatcher =
            new Regex(RegexMatchingSimpleType);

        public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>>
            CreateBindings(Type type, IBindingRoot bindingRoot)
        {
            if (type.IsInterface || type.IsAbstract)
                yield break;

            var isValidator = false;
            var validatorTarget = "";
            var match = ValidatorMatcher.Match(type.Name);
            if (match.Success)
            {
                isValidator = true;
                validatorTarget = match.Groups["name"].Value;
            }

            var isSimpleType = false;

            if (!isValidator)
                isSimpleType = SimpleTypeMatcher.IsMatch(type.Name);

            if (!isValidator && !isSimpleType)
                yield break;

            var interfaces = type.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                if ((isValidator &&
                    ValidatorMatchesInterface(@interface, validatorTarget)) ||
                    (isSimpleType && IsDefaultInterface(@interface, type)))
                {
                    yield return bindingRoot.Bind(@interface).To(type);
                }
            }
        }

        private static bool ValidatorMatchesInterface(
            Type @interface,
            string validatorTarget)
        {
            var typeName = @interface.Name;
            if (!@interface.IsGenericType)
                return typeName == "I" + validatorTarget + "Validator";

            var typeArgument = @interface.GetGenericArguments()[0].Name;
            return (typeArgument == validatorTarget ||
                typeArgument == "I" + validatorTarget) &&
                typeName == "IValidator`1";
        }

        private static bool IsDefaultInterface(Type @interface, Type type)
        {
            return @interface.Name == "I" + type.Name ||
                   @interface.Name.StartsWith("IConsumer") ||
                   @interface.Name.StartsWith("ICommandHandler");
        }
    }
}
