namespace AgendaApi.Collections.ViewModels.Result;

public class ResultViewModel<T> where T : class {
	public IList<T> Data { get; set; } = [];
	public IList<string> Errors { get; set; } = [];

	public ResultViewModel(T data, IList<string> errors) {
		Data.Add(data);
		Errors = errors;
	}

	public ResultViewModel(IList<T> data, IList<string> errors) {
		Data = data;
		Errors = errors;
	}

	public ResultViewModel(T data, string error) {
		Data.Add(data);
		Errors.Add(error);
	}

	public ResultViewModel(T data) {
		Data.Add(data);
	}

	public ResultViewModel(IList<string> errors) {
		Errors = errors;
	}

	public ResultViewModel(string error) {
		Errors.Add(error);
	}
}