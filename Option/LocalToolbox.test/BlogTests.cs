using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace LocalToolbox.test;
public class BlogTests
{
    [Fact]
    public void TestOption()
    {
        Option o = Func1(5);
        o.IsOk().Should().BeTrue();
    }

    Option Func1(int value) => value switch
    {
        <= 4 => (StatusCode.BadRequest, "Out of range"),
        _ => StatusCode.OK,
    };

    [Fact]
    public void TestOptionValue()
    {
        Option<string> o = Func2(5);
        o.IsOk().Should().BeTrue();
        o.HasValue.Should().BeTrue();

        // Two ways to get value, the "Return" is preferred because it will fail
        // when there is no value.
        o.Value.Should().Be("value is ok");
        o.Return().Should().Be("value is ok");      // preferred
    }

    Option<string> ExceuteFunc2(int value)
    {
        Option<string> o = Func2(5);
        if (o.IsError()) return o;

        return "passed";
    }

    // Different value type requires type change "ToOptionStatus<T>()"
    Option<int> ExecuteFunc2WithReturnChain(int value)
    {
        Option<string> o = Func2(5);
        if (o.IsError()) return o.ToOptionStatus<int>();

        return 100;
    }



    Option<string> Func2(int value) => value switch
    {
        <= 4 => (StatusCode.BadRequest, "Out of range"),
        _ => "value is ok",
    };

    Option<string> Func3(int value) => value switch
    {
        <= 4 => new Option<string>(StatusCode.BadRequest, "Out of range"),
        _ => new Option<string>("value is ok"),
    };


}
