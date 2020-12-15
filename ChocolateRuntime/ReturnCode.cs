namespace ChocolateRuntime {

	public class ReturnCode {

		public int Code;
		public string Message;
		public int Severity;


		public ReturnCode(int code, string message, int severity) {
			Code = code;
			Message = message;
			Severity = severity;
		}

	}
	
}
