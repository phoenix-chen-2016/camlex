﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;
using Camlex.NET.Impl;
using Camlex.NET.Interfaces;
using Camlex.NET.UnitTests.Helpers;
using Microsoft.SharePoint;
using NUnit.Framework;
using Rhino.Mocks;

namespace Camlex.NET.UnitTests
{
    [TestFixture]
    public class GenericTranslatorTests
    {
        [Test]
        public void test_THAT_where_clause_IS_rendered_to_caml_properly()
        {
            var analyzer = MockRepository.GenerateStub<IAnalyzer>();
            var operation = MockRepository.GenerateStub<IOperation>();
            var translator = new GenericTranslator(analyzer);

            Expression<Func<SPItem, bool>> expr = x => true;
            analyzer.Stub(a => a.IsValid(expr)).Return(true);
            analyzer.Stub(a => a.GetOperation(expr)).Return(operation);
            operation.Stub(o => o.ToCaml()).Return(new XElement("foo"));

            string caml = translator.TranslateWhere(expr);
            string expected = "<Where><foo /></Where>";

            Assert.That(caml, Is.EqualTo(expected).Using(new CamlComparer()));
        }
    }
}
