namespace BoardcampApiCS.Errors;

public class ConflictError : Exception {
  public ConflictError(string message) : base(message) {}
}