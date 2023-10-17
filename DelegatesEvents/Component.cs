namespace DelegatesEvents;

/// <summary>
/// Component enthält das Event und den Aufruf des Events
/// -> Entwicklerseite
/// </summary>
internal class Component
{
	public event Action ProcessStarted;

	public event Action ProcessEnded;

	public event Action<int> Progress; //Hier ein int Parameter um den Fortschritt mitzugeben

	public void DoWork()
	{
		ProcessStarted?.Invoke(); //Bei Event unbedingt ?.Invoke benutzen, um vorzubeugen das der User hier keine Methode anhängt
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(200);
			Progress?.Invoke(i);
		}
		ProcessEnded?.Invoke();
	}
}