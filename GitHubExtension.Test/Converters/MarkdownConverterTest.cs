﻿// **********************************************************************************
// The MIT License (MIT)
// 
// Copyright (c) 2014 Rob Prouse
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// **********************************************************************************

#region Using Directives

using System;
using System.Globalization;
using Alteridem.GitHub.Converters;
using NUnit.Framework;
using Alteridem.GitHub.Styles;
using Alteridem.GitHub.Interfaces;

#endregion

namespace Alteridem.GitHub.Extension.Test.Converters
{
    [TestFixture]
    public class MarkdownConverterTest
    {
        [Test]
        public void TestConvert([Values]IssueTheme theme)
        {
            var options = Factory.Get<IOptionsProvider>();
            Assert.That(options, Is.Not.Null);
            Assert.That(options.Options, Is.Not.Null);

            options.Options.IssueTheme = theme;

            var converter = new MarkdownConverter();
            string html = converter.Convert("##Header##", typeof(string), null, CultureInfo.CurrentCulture) as string;
            Assert.That(html, Is.Not.Null);
            Assert.That(html, Contains.Substring("<h2>Header</h2>"));
        }
    }
}