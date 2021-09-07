class SingletonData
{
    public static SingletonData Instance;

    private SingletonData()
    {

    }

    public static SingletonData FindInstance()
    {
        if (Instance != null) return Instance;
        else return Instance = new SingletonData();
    }
}
