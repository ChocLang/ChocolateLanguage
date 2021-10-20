using System;

namespace ChocolateRuntime {
	public class Lexer {
		public string[] SplitCode;

		public Lexer(string[] code) {
			SplitCode = code;
		}

		public ReturnCode Lex() {

			// Remove all white spaces to make it easier to lex
			for (int i = 0; i < SplitCode.Length; i++) { SplitCode[i] = SplitCode[i].Trim(); }

			// Main lexing code
			for (int i = 0; i < SplitCode.Length; i++) {
				// Ignore all single-line comments
				CheckSingleLine(ref i);
				// Lex imports
				if (SplitCode[i].StartsWith("import")) {
					string importType;
					string importParam;

					if (SplitCode[i].Split().Length == 3) {
						importType = SplitCode[i].Split()[1];
						importParam = SplitCode[i].Split()[2];
					} else {
						return ReturnCodes.CH0003(i + 1);
					}

					// Set the import type using string
					switch (importType) {
						case "csharp":
							SplitCode[i] = "GET CSHARP " + importParam;
							break;
						case "file":
							SplitCode[i] = "GET FILE " + importParam;
							break;
						case "class":
							SplitCode[i] = "GET CLASS " + importParam;
							break;
						default:
							return ReturnCodes.CH0004(i + 1, importParam);
					}
				} else if (SplitCode[i].IndexOf('(') > 0 && SplitCode[i].EndsWith(")")) {
					string functionName = SplitCode[i].Split('(')[0];
					string functionParams = SplitCode[i].Substring(SplitCode[i].IndexOf('(') + 1);
					functionParams = functionParams.Remove(functionParams.Length - 1);
					SplitCode[i] = $"CALL {functionName} */*/*/{functionParams}";
				}
			}
			return ReturnCodes.CH0000;
		}

		private void CheckSingleLine(ref int index) {
			if (SplitCode[index].StartsWith("//")) {
				SplitCode[index] = "COMMENT";
				index++;
			}
		}
	}
}
