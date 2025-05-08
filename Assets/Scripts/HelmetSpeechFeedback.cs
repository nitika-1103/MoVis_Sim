using UnityEngine;
using System.Speech.Synthesis; // Required for TTS
using System.Threading;        // We'll use this to run speech in a separate thread

public class HelmetSpeechFeedback : MonoBehaviour
{
    private SpeechSynthesizer synthesizer;
    private Thread speechThread;

    void Start()
    {
        synthesizer = new SpeechSynthesizer();
        synthesizer.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.Adult);
        synthesizer.Rate = 0; // Normal speaking rate
    }

    public void Speak(string message)
    {
        // Stop any ongoing speech
        if (speechThread != null && speechThread.IsAlive)
            speechThread.Abort();

        speechThread = new Thread(() =>
        {
            try
            {
                synthesizer.Speak(message);
            }
            catch { }
        });
        speechThread.Start();
    }

    void OnDestroy()
    {
        if (speechThread != null && speechThread.IsAlive)
            speechThread.Abort();
        synthesizer.Dispose();
    }
}
