using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Option.test;
public class TupleTests
{
    [Fact]
    public void TupleSample()
    {
        // Hard to use
        var a = new Tuple<string, int>("a", 3);
        a.Item1.Should().Be("a");
        a.Item2.Should().Be(3);

        // Easier
        var b = (value: "a", index: 5);
        b.value.Should().Be("a");
        b.index.Should().Be(5);

        (string value, int index) = ("a", 5);

        // Reduces code
        (string name, int age) = GetUser();
        name.Should().Be("user1");
        age.Should().Be(20);
    }

    private (string name, int age) GetUser() => ("user1", 20);
}
