using Cosmos.AI.Open_AI;
using Cosmos.AI;
using System.Numerics;

internal class Setup
{
	private static OpenAI ai;
	public Setup(string apiKey)
	{
		ai = new OpenAI(apiKey);
	}

	public async Task Image(string prompt)
	{
		ImageRequest request = new ImageRequest(
			prompts: prompt,        //The prompt(s) used for image generation.
			amount: 3,              //The amount of images generated using the prompt.
			size: ImageSize.p256);  //The size of the images generated.

		//Post an image request to the AI.
		ImageResponse response = await ai.ImageGeneration.Request(request);

		foreach(string url in response.Urls)
		{
			Console.WriteLine($"URL: {url}");
		}
	}

	public async void Text(string prompt)
	{
		TextRequest request = new TextRequest(
			prompts: prompt,                //The prompt(s) to generate completion for.
			model: Model.Curie,             //The model to use.
			suffix: string.Empty,           //What that comes after the completion text.
			maxTokens: 40,                  //The maximum number of tokens to generates.
			temperature: 0.7d,              //Sampling temperature "randomness"
			p: 1.0d,                        //Nucleaus sampling
			amount: 1,                      //The amount of completions to generate.
			echo: false,                    //Echos back the prompt in addition to the completion.
			stopSequence: string.Empty);    //A sequence that stops the AI from generating further tokkens.

		//Post a text completion request to the AI.
		TextResponse response = await ai.TextCompletion.Request(request);

		foreach(var resp in response)
		{
			Console.WriteLine(resp.Response);
		}
	}
}