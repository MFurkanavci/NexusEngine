using UnityEngine;

public class ExperienceManager
{
    private int currentExperience;
    private int experienceToLevelUp;

    public int CurrentExperience => currentExperience;
    public int ExperienceToLevelUp => experienceToLevelUp;

    // Define a delegate type for level up events
    public delegate void LevelUpDelegate(int newLevel);
    public event LevelUpDelegate OnLevelUp; // Event to subscribe to level up events

    public ExperienceManager(int initialExperience, int initialExperienceToLevelUp)
    {
        currentExperience = initialExperience;
        experienceToLevelUp = initialExperienceToLevelUp;
    }

    public void AddExperience(int amount)
    {
        currentExperience += amount;

        while (currentExperience >= experienceToLevelUp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        // Increase level and adjust experience values
        currentExperience -= experienceToLevelUp;
        experienceToLevelUp *= 2;

        // Trigger the level up event and pass the new level as an argument
        OnLevelUp?.Invoke(experienceToLevelUp / 100);
    }
}
