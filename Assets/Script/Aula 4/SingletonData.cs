class SingletonData
{
    private static SingletonData Instance;

    private SingletonData()
    {

    }

    public void Write(string text)
    {

    }

    public string Read()
    {
        return "";
    }

    public static SingletonData FindInstance()
    {
        if (Instance != null) return Instance;
        else return Instance = new SingletonData();
    }
}
