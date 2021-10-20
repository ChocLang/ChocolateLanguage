using System;
using System.IO;

namespace ChocolateRuntime {

    public class Compiler {
        // The file to lex
        public string FileName;

        public Compiler(string filename) {
            FileName = filename;
        }

        public ReturnCode Run() {
            string[] contents;

			try {
                contents = File.ReadAllLines(FileName);
            } catch (Exception) {
                return ReturnCodes.CH0002;
			}
            Lexer lexer = new Lexer(contents);
            ReturnCode LexCode = lexer.Lex();
            if (LexCode.Severity != Severity.Success) {
                return LexCode;
			}
            Parser parser = new Parser(lexer.SplitCode);
            ReturnCode ParseCode = parser.ParseAndRun();
            return ParseCode;
        }
    }
}
