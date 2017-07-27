//拖动站位信息窗口
function getRiverCoords(strRiverName) {
    var slHost = document.getElementById("SL");
    var page = slHost.content.WebSL;


    //var sCoords = readFile("mapLatLon/river/浙江/" + strRiverName + ".txt");
    var sCoords = readFile("../mapLatLon/river/浙江/上塘河.txt");
    //var sCoords;

    ///////////////////////////
    //$.ajax({

    //    url: '../mapLatLon/river/浙江/上塘河.txt',

    //    dataType: 'text',

    //    error: function (xhr) { alert(xhr.responseText); },

    //    success: function (data) {
    //        sCoords = data;
    //        alert(sCoords);
    //        return sCoords;
            
    //    }
    //});


    //////////////////////////

    
    alert(sCoords);
    return sCoords;
    
    //page.getRiverCoords(sCoords);
}