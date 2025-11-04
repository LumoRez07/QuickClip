using GenerativeAI;
using System;
using System.IO;
using System.Threading.Tasks;

namespace QuickClip
{
    public static class GeminiHelper
    {
        public static async Task<string> ProcessWithGemini(string mode, string input, string apiKey, string customPrompt, string outputFolder)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(apiKey))
                    throw new Exception("API key not found. Please set it in AI Integration settings.");

                if (string.IsNullOrWhiteSpace(input))
                    throw new Exception("No text provided to process.");

                var googleAI = new GoogleAi(apiKey);
                var model = googleAI.CreateGenerativeModel("gemini-2.5-flash");

                string prompt = mode switch
                {
                    "grammar" => $"Check and correct grammar for the following text while preserving meaning. Return only the corrected text:\n\n{input}",
                    "summarize" => $"Summarize the following text concisely:\n\n{input}",
                    "customprompt" => string.IsNullOrWhiteSpace(customPrompt)
                        ? $"Process the following text:\n\n{input}"
                        : $"{customPrompt}\n\n{input}",
                    _ => input
                };

                var response = await model.GenerateContentAsync(prompt);

                if (response == null)
                    throw new Exception("Received empty response from Gemini API.");

                string result = response.Text();

                if (string.IsNullOrWhiteSpace(result))
                    throw new Exception("Gemini API returned empty text.");

                // Create output directory if it doesn't exist
                if (string.IsNullOrWhiteSpace(outputFolder))
                {
                    outputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "QuickClip", "AI");
                }

                Directory.CreateDirectory(outputFolder);

                string fileName = $"{mode}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string filePath = Path.Combine(outputFolder, fileName);

                File.WriteAllText(filePath, result);

                return filePath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Gemini processing error: {ex.Message}");
            }
        }
    }
}