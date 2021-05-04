[System.Serializable]

public class QuestionAndAnswer 
{
    public string Question;
    public string[] Answers;
    public int correctAnswer;
    public Continent continent;
}


public enum Continent
{

    Asia,Africa,Europe, Australia, North_america,South_america

}
