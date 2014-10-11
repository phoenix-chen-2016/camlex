﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamlexNET.UnitTests.Helpers;
using NUnit.Framework;

namespace CamlexNET.UnitTests
{
    [TestFixture]
    public class CamlexListJoinTests
    {
        [Test]
        public void test_THAT_single_left_join_IS_translated_properly()
        {
            string caml = Camlex.Query().Joins().Left(x => x["test"].ForeignList("foo")).ToString();
            string expected =
               "<Join Type=\"LEFT\" ListAlias=\"foo\">" +
               "    <Eq>" +
               "      <FieldRef Name=\"test\" RefType=\"Id\"/>" +
               "      <FieldRef List=\"foo\" Name=\"Id\"/>" +
               "    </Eq>" +
               "</Join>";

            Assert.That(caml, Is.EqualTo(expected).Using(new CamlComparer()));
        }

        [Test]
        public void test_THAT_single_left_join_with_primary_list_IS_translated_properly()
        {
            string caml = Camlex.Query().Joins().Left(x => x["test"].PrimaryList("foo").ForeignList("bar")).ToString();
            string expected =
               "<Join Type=\"LEFT\" ListAlias=\"bar\">" +
               "    <Eq>" +
               "      <FieldRef List=\"foo\" Name=\"test\" RefType=\"Id\"/>" +
               "      <FieldRef List=\"bar\" Name=\"Id\"/>" +
               "    </Eq>" +
               "</Join>";

            Assert.That(caml, Is.EqualTo(expected).Using(new CamlComparer()));
        }

        [Test]
        public void test_THAT_single_projected_field_IS_translated_properly()
        {
            string caml = Camlex.Query().ProjectedFields(x => x["test"].List("foo").ShowField("Title"));
            string expected = "<Field Name=\"test\" Type=\"Lookup\" List=\"foo\" ShowField=\"Title\"/>";

            Assert.That(caml, Is.EqualTo(expected).Using(new CamlComparer()));
        }
    }
}