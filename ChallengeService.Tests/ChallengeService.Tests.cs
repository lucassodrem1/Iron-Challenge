using Xunit;
using Challenge.Services;
using FluentAssertions;

namespace Challenge.Tests
{
    public class ChallengeTest
    {
        [Fact]
        public void OldPhonePad_InputIsEmptyString_ReturnEmptyString()
        {
            string result = ChallengeService.OldPhonePad(""); 

            result.Should().BeEmpty();
        }

        [Fact]
        public void OldPhonePad_InputIsBackspaces_ReturnEmptyString()
        {
            string result = ChallengeService.OldPhonePad("****"); 

            result.Should().BeEmpty();
        }

        [Fact]
        public void OldPhonePad_InputIsEnter_ReturnEmptyString()
        {
            string result = ChallengeService.OldPhonePad("#"); 

            result.Should().BeEmpty();
        }

        [Fact]
        public void OldPhonePad_InputIsSpaces_ReturnEmptyString()
        {
            string result = ChallengeService.OldPhonePad("     #"); 

            result.Should().BeEmpty();
        }

        [Fact]
        public void OldPhonePad_InputIsNumbers_ReturnTuring()
        {
            string result = ChallengeService.OldPhonePad("8 88777444666*664#"); 

            result.Should().Be("TURING");
        }

        [Fact]
        public void OldPhonePad_InputIsRepeatedNumbers_ReturnA()
        {
            string result = ChallengeService.OldPhonePad("2222222222222222#");

            result.Should().Be("A");
        }

        [Fact]
        public void OldPhonePad_InputIsUnsualSpacing_ReturnB()
        {
            string result = ChallengeService.OldPhonePad("  22 7 * #");

            result.Should().Be("B");
        }

        [Fact]
        public void OldPhonePad_InputIsUnsualBackSpacing_ReturnQ()
        {
            string result = ChallengeService.OldPhonePad("22******77#");

            result.Should().Be("Q");
        }
    }
}