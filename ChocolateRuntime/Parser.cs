using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace ChocolateRuntime {
	public class Parser {

		public string[] LexedCode;
		Dictionary<string, string> availableMethods = new Dictionary<string, string> { };

		public Parser(string[] lexed) {
			LexedCode = lexed;
		}

		public ReturnCode ParseAndRun() {
			for (int i = 0; i < LexedCode.Length; i++) {
				if (LexedCode[i].StartsWith("GET")) {
					switch (LexedCode[i].Split(' ')[1]) {
						case "CSHARP":
							string _class = LexedCode[i].Split()[2];
							Type type = GetType(_class);
							MethodInfo[] methodInfo = type.GetMethods();
							foreach (var method in methodInfo) {
								availableMethods[method.Name] = _class;
							}
							break;
						case "FILE":
							break;
						case "CLASS":
							break;
					}
				} else if (LexedCode[i].StartsWith("CALL")) {
					// TODO: Parse parameter type and create Type array
					string paramsUnparsed = LexedCode[i].Split("*/*/*/")[1];
					object[] _params = paramsUnparsed.Split(" ,, ");
					object[] finalParams = new object[_params.Length];
					string name = LexedCode[i].Split()[1];
					Type[] paramTypes = new Type[_params.Length];

					int j = 0;
					
					foreach (string param in _params) {
						var isNumber = IsNumber(param).Result[0];
						string res = IsNumber(param).Result[1].ToString();
						if (isNumber as string == "true") {
							paramTypes[j] = typeof(float);
							finalParams[j] = float.Parse(res);
						} else {
							paramTypes[j] = typeof(string);
							finalParams[j] = _params[j];
						}
						j++;
					}
					if (availableMethods.ContainsKey(name)) {
						string _class = availableMethods[name];
						MethodInfo method = GetType(_class).GetMethod(name, paramTypes);
						method.Invoke(GetType(_class), finalParams);
					} else {
						return ReturnCodes.CH0005(i + 1, name);
					}
				}
			}
			return ReturnCodes.CH0000;
		}

		public static Type GetType(string typeName) {
			var type = Type.GetType(typeName);
			if (type != null) return type;
			foreach (var a in AppDomain.CurrentDomain.GetAssemblies()) {
				type = a.GetType(typeName);
				if (type != null)
					return type;
			}
			return null;
		}

		async Task<object[]> IsNumber(string str) {
			object[] retArray = { "false", "" };
			try {
				var res = await CSharpScript.EvaluateAsync(str);
				float.Parse(res.ToString());
				retArray[1] = res;
				retArray[0] = "true";
			} catch {
				retArray[0] = "false";
			}
			return retArray;
		}
	}
}