var searchReq_a = createReq_a();
//创建XMLhttpReq_auest
function createReq_a() {
    var httpReq_a;

    if (window.XMLhttpRequest) {
        httpReq_a = new XMLhttpRequest();
        if (httpReq_a.overrideMimeType) {
            httpReq_a.overrideMimeType('text/xml');
        }
    }
    else if (window.ActiveXObject) {
        try {
            httpReq_a = new ActiveXObject('Msxml2.XMLHTTP');
        }
        catch (e) {
            try {
                httpReq_a = new ActiveXObject('Microsoft.XMLHTTP');
            }
            catch (e) {
            }
        }
    }
    return httpReq_a;
}
//发送HTTP请求，当输入框的内容变化时，会调用该函数
function searchSuggest_a() {
    var str = escape(document.getElementById("txtmd").value);
    searchReq_a.open("get", "../tools/Server_md.aspx?searchText=" + str, true);
    searchReq_a.onreadystatechange = handlesearchSuggest_a;
    searchReq_a.send(null);
}

//当 onreadystatechange 值变化时，会调用该函数
//注意searchSuggest_a()中的这一句searchReq_a.onreadystatechange = handlesearchSuggest_a;
function handlesearchSuggest_a() {
    if (searchReq_a.readyState == 4) {
        if (searchReq_a.status == 200) {
            var suggestText = document.getElementById("search_suggest_a");
            var sourceText = searchReq_a.responseText.split("\n");
            if (sourceText.length > 1) {
                suggestText.style.display = "";
                suggestText.innerHTML = "";
                for (var i = 0; i < sourceText.length - 1; i++) {
                    var s = '<div onmouseover="javascript:suggestOver_a(this);"';
                    s += ' onmouseout="javascript:suggestOut_a(this);" ';
                    s += ' onclick="javascript:setSearch_a(this.innerHTML);" ';
                    s += ' class="suggest_link_a">' + sourceText[i] + '</div>';
                    suggestText.innerHTML += s;
                }
            }
            else {
                suggestText.style.display = "none";
            }
        }
    }
}
function suggestOver_a(div_value) {
    div_value.className = "suggest_link_over_a";
}

function suggestOut_a(div_value) {
    div_value.className = "suggest_link_a";
}
function setSearch_a(obj) {
    document.getElementById("txtmd").value = obj;
    var div = document.getElementById("search_suggest_a");
    div.innerHTML = "";
    div.style.display = "none";
}
function tbblur_a() {
    var div = document.getElementById("search_suggest_a");
    div.style.display = "none";
}
