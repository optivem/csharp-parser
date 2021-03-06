﻿using Microsoft.CodeAnalysis.CSharp;
using Generator.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Core.Domain.Generators
{
    public class IdentityGenerator : Generator
    {
        private const string SourceCode = @"using Atomiv.Core.Domain;

namespace Generator.Core.Domain.Customers
{
    public class CustomerIdentity : Identity<int>
    {
        public static readonly CustomerIdentity Null = new CustomerIdentity(0);

        public CustomerIdentity(int id) : base(id)
        {
        }
    }
}";

        private const string Key = "Customer";

        public IdentityGenerator(AggregateModel model) : base(model)
        {
        }

        public override string Generate()
        {
            var sourceCode = SourceCode.Replace(Key, Model.SingularName);

            var tree = CSharpSyntaxTree.ParseText(sourceCode);

            var sourceText = tree.GetText();

            return sourceText.ToString();
        }
    }
}
