namespace UnitTestingExample
{
    public class StringTests
    {
        [AwesomeTest]
        public void Trim_method_should_remove_chars_in_the_beginning_and_end_of_string()
        {
            //arange
            var input = "abcd ";
            //act
            var result = input.Trim(new[] { ' ', 'a' });

            // assert
            MyAsserts.IsEqual("bcd", result);
        }
    }

    public class TaxProviderTests
    {

    }
}
