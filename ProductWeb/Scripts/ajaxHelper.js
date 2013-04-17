/*
 * AjaxHelper - A JavaScript Helper
 * 
 *
 * Copyright (c) 2012 TaoPlat
 * Dual licensed under the MIT (MIT-LICENSE.txt)
 * and GPL (GPL-LICENSE.txt) licenses.
 */

/***
 * ajax获取服务端数据
 * @url 业务数据
 * @data
 */
function doAjaxGet(url, fn) {
    $.ajax({
        url: url,
        type: "GET",
        dataType: 'json',
        contentType: 'application/json',
        beforeSend: setHeader,
        success: fn
    });
}

function doAjaxPost(url, data, fn) {
    $.ajax({
        url: url,
        type: 'POST',
        data: data,
        dataType: 'json',
        contentType: 'application/json',
        success: fn
    });
}

//设置Header, Name and value
function setRequestHeader(xhr, headerName, value) {
    xhr.setRequestHeader(headerName, value);
}


//按名称读取Cookie值
function getCookie(cookieName) {
    var cookieString = RegExp("" + cookieName + "[^;]+").exec(document.cookie);
    return unescape(!!cookieString ? cookieString.toString().replace(/^[^=]+/, "").replace("=", "") : "");
}

//设置header
function setHeader(xhr) {
    var ticket = 'Basic ' + getCookie(".AuthCookie");
    xhr.setRequestHeader('Authorization', ticket);
}

//添加cookie
function setCookie(c_name, value, exdays) {
    var exdate = new Date();
    exdate.setDate(exdate.getDate() + exdays);
    var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
    var c_domain = '.localhost';
    document.cookie = c_name + "=" + c_value + ";path=/" + ";domain=" + c_domain;
}

//删除cookie
function removeCookie(c_name) {
    //当设置过期时间为负数时，会清除cookie
    setCookie(c_name, '', -7);
}

function checkCookie() {
    var username = getCookie("username");
    if (username != null && username != "") {
        alert("Welcome again " + username);
    }
    else {
        username = prompt("Please enter your name:", "");
        if (username != null && username != "") {
            setCookie("username", username, 365);
        }
    }
}

//读取QueryString里的Name
function getUrlQueryStringByName(name) {
    var match = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
    return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
}

//字符串类型转换为Boolean类型
function parseBool(val) {
    if ((typeof val === "string" && (val.toLowerCase() === 'true' || val.toLowerCase() === 'yes')) || val === 1)
        return true;
    else if ((typeof val === "string" && (val.toLowerCase() === 'false' || val.toLowerCase() === 'no')) || val === 0)
        return false;

    return null;
}

//判断是否是数字类型，如果是返回true, 否则返回false
function isNumber(o) {
    return !isNaN(o - 0) && o !== null && o !== "" && o !== false;
}

//字符串转换为Integer
Number.tryParseInt = function (str, defaultValue) {
    if (isNumber(str) == true) {
        return parseInt(str);
    }

    var retValue = defaultValue;
    if (str != null) {
        if (str.length > 0) {
            if (!isNaN(str)) {
                retValue = parseInt(str);
            }
        }
    }
    return retValue;
}

//字符串转换为Float
Number.tryParseFloat = function (str, defaultValue) {
    if (isNumber(str) == true) {
        return parseFloat(str);
    }

    var retValue = defaultValue;
    if (str != null) {
        if (str.length > 0) {
            if (!isNaN(str)) {
                retValue = parseFloat(str);
            }
        }
    }
    return retValue;
}

//替换字符串中包含的全部匹配字串
String.prototype.replaceAll = function (stringToFind, stringToReplace) {
    var temp = this;
    var index = temp.indexOf(stringToFind);
    while (index != -1) {
        temp = temp.replace(stringToFind, stringToReplace);
        index = temp.indexOf(stringToFind);
    }
    return temp;
}
//})(jQuery);