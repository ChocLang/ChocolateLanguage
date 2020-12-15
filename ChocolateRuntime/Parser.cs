namespace ChocolateRuntime {
    public class Parser {

        public string[] LexedCode;

        public Parser(string[] lexed) {
            LexedCode = lexed;
        }

        public ReturnCode ParseAndRun() {

            return ReturnCodes.CH0000;
        }

    }
}