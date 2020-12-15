namespace ChocolateRuntime {

	public static class ReturnCodes {

		/// <summary>
		/// CH0000 - Success
		/// </summary>
		public static ReturnCode CH0000 = new ReturnCode(0, "CH0000: Success", Severity.Success);

		/// <summary>
		/// CH0001 - Internal compiler error
		/// </summary>
		public static ReturnCode CH0001 = new ReturnCode(1, "CH0001: Internal compiler error", Severity.Error);

		/// <summary>
		/// CH0002 - File not found
		/// </summary>
		public static ReturnCode CH0002 = new ReturnCode(2, "CH0002: File not found", Severity.Error);

		/// <summary>
		/// CH0003 - Source file not found
		/// </summary>
		public static ReturnCode CH0003 = new ReturnCode(3, "CH0003: The source file provided was not found", Severity.Error);

		/// <summary>
		/// CH0004 - Import type and/or name not specified
		/// </summary>
		public static ReturnCode CH0004(int line) {
			return new ReturnCode(4, $"CH0004: Type and/or name not specified for statement import at line {line}", Severity.Error);
		}

		/// <summary>
		/// CH0005 - Invalid import type
		/// </summary>
		/// <param name="invalidType">
		/// The invalid import type supplied by user
		/// </param>
		/// <param name="line">
		/// The line number on which the invalid import statement exists
		/// </param>
		public static ReturnCode CH0005(int line, string invalidType) {
			return new ReturnCode(5, $"CH0005: Invalid type \"{invalidType}\" specified for statement import at line {line}", Severity.Error);
		}
	}

}