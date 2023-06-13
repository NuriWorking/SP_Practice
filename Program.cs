//텍스트 파일 읽어서 출력
static void PrintFile(string filename)
{
    string line;
    StreamReader file = new StreamReader(filename);
    while ((line = file.ReadLine()) != null)
    {
        System.Console.WriteLine(line);
    }
    file.Close();
}
//PrintFile(".\\data\\print_sample.txt");

//텍스트 파일 읽어서 특정 위치에 복사
static void CopyFile(string InputFilename, string OutputFilename)
{
    const int BUF_SIZE = 4096;
    byte[] buffer = new byte[BUF_SIZE];
    int nFReadLen;
    FileStream fs_in =
    new FileStream(InputFilename, FileMode.Open, FileAccess.Read);
    FileStream fs_out =
    new FileStream(OutputFilename, FileMode.Create, FileAccess.Write);
    while ((nFReadLen = fs_in.Read(buffer, 0, BUF_SIZE)) > 0)
    {
        fs_out.Write(buffer, 0, nFReadLen);
    }
    fs_in.Close();
    fs_out.Close();
}
//CopyFile(".\\data\\print_sample.txt", ".\\data\\print_sample_copy.txt");

//특정 위치에 존재하는 파일 리스트 출력
void FileDirList(string path)
{
    string[] subdirectoryEntries = Directory.GetDirectories(path);
    foreach (string subdirectory in subdirectoryEntries)
        Console.WriteLine("[{0}]", subdirectory);
    string[] fileEntries = Directory.GetFiles(".");
    foreach (string fileName in fileEntries)
        Console.WriteLine(fileName);
}
//FileDirList(".");

//특정 위치 하위에 존재하는 모든 파일 리스트 출력
void FileDirAllList(string path)
{
    DirectoryInfo di = new DirectoryInfo(path);
    FileInfo[] fiArr = di.GetFiles("*.*", SearchOption.AllDirectories);
    foreach (var f in fiArr)
    {
        Console.WriteLine(f.Name);
    }
}
//FileDirAllList(".");


//1.INPUT 폴더 하위에 위치한 파일들의 파일명(상대경로 포함), 크기를 Console화면에
//출력하시오. 
//2. INPUT 폴더 하위에 위치한 파일들 중 크기가 3Kbyte가 넘는 파일들은 모두
//OUTPUT 폴더로 복사하시오. (OUTPUT 폴더 및 서브 폴더 생성)
//단, 파일 복사 시 바이너리 파일을 버퍼에 읽고 쓰는 방식으로 구현하고, 버퍼의 크기는
//512Byte로 설정하시오.
static void MyCopyFile(string path, string filename)
{
    string inFile = ".\\INPUT\\" + path + "\\" + filename;
    string outPath = ".\\OUTPUT\\" + path;
    string outFile = outPath + "\\" + filename;

    System.IO.Directory.CreateDirectory(outPath);

    const int BUF_SIZE = 512;
    byte[] buffer = new byte[BUF_SIZE];
    int nFReadLen;

    FileStream fs_in = new FileStream(inFile, FileMode.Open, FileAccess.Read);
    FileStream fs_out = new FileStream(outFile, FileMode.Create, FileAccess.Write);
    while ((nFReadLen = fs_in.Read(buffer, 0, BUF_SIZE)) > 0)
    {
        fs_out.Write(buffer, 0, nFReadLen);
    }
    fs_in.Close();
    fs_out.Close();
}
void Run_IO_1()
{
    DirectoryInfo di = new DirectoryInfo("./INPUT");
    FileInfo[] fiArr = di.GetFiles("*.*", SearchOption.AllDirectories);
    foreach (var f in fiArr)
    {
        long fSize = f.Length;
        string fName = f.Name;
        string path = f.DirectoryName.Substring(di.FullName.Length);

        Console.WriteLine(".{0}\\{1}: {2}bytes.", path, fName, fSize);

        if (f.Length > 3 * 1024) // 3Kbyte
        {
            MyCopyFile(path, fName);
        }
    }
}
//Run_IO_1();

void ListBasic()
{
    List<string> al = new List<string>();
    al.Add("Michael Knight");
    al.Add("Mac Guyver");
    al.Add("Clark Kent");
    al.Add("Bruce Wayne");
    al.Add("Tony Stark");
    foreach (string name in al)
    {
        Console.WriteLine(name);
    }
    Console.WriteLine();
    al.Remove("Clark Kent");
    for (int i = 0; i < al.Count; i++)
    {
        Console.WriteLine(al[i]);
    }
    Console.WriteLine();
    al.Remove(al[0]);
    var enumerator = al.GetEnumerator();
    while (enumerator.MoveNext())
    {
        Console.WriteLine(enumerator.Current);
    }
}
//ListBasic();

void ListSort()
{
    List<string> al = new List<string>();
    al.Add("Michael Knight"); al.Add("Mac Guyver");
    al.Add("Clark Kent"); al.Add("Bruce Wayne"); al.Add("Tony Stark");
    al.Sort();// a~z 오름차순
    foreach (string name in al)
    {
        Console.WriteLine(name);
    }
    Console.WriteLine();

    //내림차순 → y, x 자리변경 시 오름차순
    al.Sort(delegate (string x, string y)
    {        
        return y.CompareTo(x); //CompareTo: 같으면 0, 왼<오면 -1, 오>왼이면 1
    });
    foreach (string name in al)
    {
        Console.WriteLine(name);
    }
    Console.WriteLine();

    //오름차순
    al.Sort((x, y) => x.CompareTo(y)); 
    foreach (string name in al)
    {
        Console.WriteLine(name);
    }
    Console.WriteLine();

    al.Sort((string x, string y) => x.CompareTo(y));
    foreach (string name in al)
    {
        Console.WriteLine(name);
    }
}
//ListSort();

void DictionaryBasic()
{
    Dictionary<string, string> m = new Dictionary<string, string>();
    m.Add("kit@gmail.com", "Michael Knight");
    m.Add("knife@gmail.com", "Mac Guyver");
    m.Add("superman@gmail.com", "Clark Kent");
    m.Add("batman@gmail.com", "Bruce Wayne");
    m.Add("ironman@gmail.com", "Tony Stark");
    foreach (KeyValuePair<string, string> items in m)
    {
        Console.WriteLine(items.Key + " : " + items.Value);
    }
    Console.WriteLine();
    m.Remove("superman@gmail.com");
    foreach (KeyValuePair<string, string> items in m)
    {
        Console.WriteLine(items.Key + " : " + items.Value);
    }
    Console.WriteLine();
    m["batman@gmail.com"] = "Robin";
    foreach (KeyValuePair<string, string> items in m)
    {
        Console.WriteLine(items.Key + " : " + items.Value);
    }
}
//DictionaryBasic();

void QueueBasic()
{
    List<string> numberList = new List<string>();
    numberList.Add("one");
    numberList.Add("two");
    numberList.Add("three");
    Console.WriteLine("Queue Count = {0}", numberList.Count);
    foreach (string number in numberList)
    {
        Console.WriteLine(number);
    }
    Console.WriteLine("Deque '{0}'", numberList[0]);
    numberList.RemoveAt(0);
    Console.WriteLine("Peek : {0}", numberList[0]);
    Console.WriteLine("Contains(\"three\") = {0}", numberList.Contains("three"));
    numberList.Clear();
    Console.WriteLine("Queue Count = {0}", numberList.Count);
}
//QueueBasic();

void QueueBasic2()
{
    Queue<string> numberQ = new Queue<string>();
    numberQ.Enqueue("one");
    numberQ.Enqueue("two");
    numberQ.Enqueue("three");
    Console.WriteLine("Queue Count = {0}", numberQ.Count);
    foreach (string number in numberQ)
    {
        Console.WriteLine(number);
    }
    Console.WriteLine("Deque '{0}'", numberQ.Dequeue());
    Console.WriteLine("Peek : {0}", numberQ.Peek());
    Console.WriteLine("Contains(\"three\") = {0}", numberQ.Contains("three"));
    numberQ.Clear();
    Console.WriteLine("Queue Count = {0}", numberQ.Count);
}
QueueBasic2();