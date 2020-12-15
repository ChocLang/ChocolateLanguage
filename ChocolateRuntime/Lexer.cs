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

			// Main lex code
			for (int i = 0; i < SplitCode.Length; i++) {
				// Ignore all single-line comments
				CheckSingleLine(ref i);
				// Ignore all multiline comments
				CheckMultiline(ref i);
				// Ignore all single-line comments again as i may have gotten increased
				CheckSingleLine(ref i);

				// Lex imports
				if (SplitCode[i].StartsWith("import")) {
					string importType;
					string importParam;

					if (SplitCode[i].Split().Length == 3) {
						importType = SplitCode[i].Split()[1];
						importParam = SplitCode[i].Split()[2];
					} else {
						return ReturnCodes.CH0004(i + 1);
					}

					// Set the import type using string
					switch (importType) {
						case "csharp":
							SplitCode[i] = $"GET CSHARP " + importParam;
							break;
						case "file":
							SplitCode[i] = $"GET FILE " + importParam;
							break;
						case "class":
							SplitCode[i] = $"GET CLASS " + importParam;
							break;
						default:
							return ReturnCodes.CH0005(i + 1, importParam);
					}
				}
			}

			return ReturnCodes.CH0000;
		}

		private void CheckSingleLine(ref int index) {
			if (SplitCode[index].StartsWith("//")) { 
				index++;
			}
		}

		private void CheckMultiline(ref int index) {
			if (SplitCode[index].StartsWith("/*")) {
				goto checkMultiline;
				checkMultiline: if (SplitCode[index].EndsWith("*/")) {
					index++;
				} else {
					index++;
					goto checkMultiline;
				}
			}
		}
	}
}