/*
  文件作用：文件操作相关
  author:du
  date:20130827
*/

function readFile(filename) {
    var fso = new ActiveXObject("Scripting.FileSystemObject");
    var f = fso.OpenTextFile(filename, 1);
    var s = "";
    while (!f.AtEndOfStream)
        s += f.ReadLine() + "\n";
    f.Close();
    return s;
}

//写文件     
function writeFile(filename, filecontent) {
    var fso, f, s;
    fso = new ActiveXObject("Scripting.FileSystemObject");
    f = fso.OpenTextFile(filename, 8, true);
    f.WriteLine(filecontent);
    f.Close();
    alert('ok');
}