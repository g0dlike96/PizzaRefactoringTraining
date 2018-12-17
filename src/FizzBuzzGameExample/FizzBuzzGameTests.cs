using System.IO;
using Xunit;

namespace FizzBuzzGameExample
{
    public class FizzBuzzGameTests
    {

        [Fact]
        public void When_play_1_should_return_1()
        {
            // arrange
            var game = new FizzBuzz();

            // act
            var result = game.Play(1);

            // assert
            Assert.Equal("1", result);
        }

        [Fact]
        public void When_play_2_should_return_2()
        {
            var game = new FizzBuzz();
            var result = game.Play(2);
            Assert.Equal("2", result);
        }

        [Fact]
        public void When_play_3_should_return_Fizz()
        {
            var game = new FizzBuzz();
            var result = game.Play(3);
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void When_play_5_should_return_Buzz()
        {
            var game = new FizzBuzz();
            var result = game.Play(5);
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void When_play_15_should_return_FizzBuzz()
        {
            var game = new FizzBuzz();
            var result = game.Play(15);
            Assert.Equal("FizzBuzz", result);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Surename { get; set; }

        public int Age { get; set; }
        public SexKind Sex { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surename}";
        }
    }

    public enum SexKind
    {

    }
}
