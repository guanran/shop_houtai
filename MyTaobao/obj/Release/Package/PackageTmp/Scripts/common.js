

//上传服务器地址
//var UploadUrl = "http://pic.ehousechina.com/Service/ImageUpload";
var UploadUrl = "http://pic.ehousechina.com/Service/ImageUploadYF";
var UploadUrl2 = "http://pic.ehousechina.com/Service/UpLoadFangYouImg";
var UploadUrlPath = "http://pic.ehousechina.com/";
var MediaUploadUrl = "http://pic.ehousechina.com/Service/MediaUpload";
var UploadUrl_large = "http://pic.ehousechina.com/Service/LargePicUpload";
var PublishUrl = "http://weixin.ltchina.com/";
//var UploadUrl = "http://172.28.20.119:88/Service/ImageUpload";
//var UploadUrlPath = "http://172.28.20.119:88/";
//var PublishUrl = "http://172.28.20.119:88/";
var QRPrefix = "http://";

var UploadCss = {
    //swf: '/assets/plugins/uploadify/uploadify.swf',
    swf: '/assets/plugins/uploadify2/uploadify.swf',
    cancelImg: '/assets/plugins/uploadify/uploadify-cancel.png'
};

var cookiename = ["eju_project", "eju_recommend", "eju_share", "eju_discount"]

var GamePersonType = '总共,1,每天,2';
/**
* 设置cookies
* @param {String} key 
* @param {String} value 
*/
var SetCookie = function (key, value) {
    var argv = SetCookie.arguments;
    var argc = SetCookie.arguments.length;
    var expires = (argc > 2) ? argv[2] : null;
    if (expires != null) {
        var LargeExpDate = new Date();
        LargeExpDate.setTime(LargeExpDate.getTime() + (expires * 1000 * 3600 * 24));
    }
    document.cookie = key + "=" + encodeURIComponent(value) + ((expires == null) ? "" : ("; expires=" + LargeExpDate.toGMTString()));
};


/**
* 获取Cookie对应值
* @param {String} key
* @return {String}
*/
var GetCookie = function (key) {
    var arr = document.cookie.match(new RegExp("(^| )" + key + "=([^;]*)(;|$)"));
    if (arr != null) {
        return decodeURIComponent(arr[2]);
    } else {
        return null;
    }
};

/*判断是否是手机号码*/
var validatemobile = function (mobile) {
    if (mobile.length == 0) {
        return false;
    }
    if (mobile.length != 11) {
        return false;
    }

    var myreg = /^((13[0-9]|14[5|7]|15[0-9]|18[0-9]|17[0-9])[0-9]{8})$/;
    if (!myreg.test(mobile)) {
        return false;
    }
    return true;
}

var validateCardNo = function (cardNo) {
    var reg = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$|^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$/;
    if (reg.test(cardNo) === false) {
        return false;
    }
    return true;
}

var showloading = function (text) {
    if (typeof (text) == "undefined" || text == null) {
        text = "保存中...";
    }
    $("#beforebox-loading div").text(text);
    $("#beforebox-overlay").show();
}

var hideloading = function () {
    $("#beforebox-overlay").hide();
}

function IsURL(str_url) {
    var strRegex = "^((https|http|ftp|rtsp|mms)?://)"
    + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //ftp的user@
    + "(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP形式的URL- 199.194.52.184
    + "|" // 允许IP和DOMAIN（域名）
    + "([0-9a-z_!~*'()-]+\.)*" // 域名- www.
    + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // 二级域名
    + "[a-z]{2,6})" // first level domain- .com or .museum
    + "(:[0-9]{1,4})?" // 端口- :80
    + "((/?)|" // a slash isn't required if there is no file name
    + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
    var re = new RegExp(strRegex);
    //re.test()
    if (re.test(str_url)) {
        return (true);
    } else {
        return (false);
    }
}
/*验证是否为带小数点的数字*/
function IsDoubleNum(str) {
    //正则表达式匹配不到负号的情况
    if (str.indexOf("-") >= 0) {
        return false;
    }
    var strRegex = "[1-9]\d*[.]?\d*";
    var re = new RegExp(strRegex);
    if (re.test(str)) {
        return (true);
    } else {
        return (false);
    }
}
/*验证是否为整数*/
function IsInt(str) {
    var strRegex = /^[1-9]*[1-9][0-9]*$|^0$/;
    var re = new RegExp(strRegex); 
    if (re.test(str)) {
        return (true);
    } else {
        return (false);
    }
}

/*验证日期*/
function IsDate(str) {
    var strRegex = "[1-2][0-9]{3}-[0-1][1-9]-[0-3][0-9]";
    var re = new RegExp(strRegex);
    if (re.test(str)) {
        return (true);
    } else {
        return (false);
    }
}
/*验证时间*/
function IsTime(str) {
    var strRegex = "[0-5]{0,1}[0-9]:[0-5]{0,1}[0-9]";
    var re = new RegExp(strRegex);
    if (re.test(str)) {
        return (true);
    } else {
        return (false);
    }
}

/*导出表格*/
function ExportToExcel(tableid, tablename) {
    var table = document.getElementById(tableid);
    if (!table) {
        return;
    }

    var data = "<table border=\"1\">" + table.innerHTML + "</table>";

    var objBody = document.getElementsByTagName("body").item(0);

    //var objExpTemp = $('objExpTemp');
    var objExpTemp = document.getElementById("objExpTemp");

    if (!objExpTemp) {

        objExpTemp = document.createElement("iframe");
        objExpTemp.setAttribute('id', 'objExpTemp');
        objExpTemp.style.display = 'none';
        objExpTemp.src = 'about:blank';
        objBody.appendChild(objExpTemp);
    }

    var ExcelForm = objExpTemp.contentWindow.document.forms['ExcelForm'];
    if (!ExcelForm) {
        objExpTemp.contentWindow.document.write('<div style="display:none"><form name=ExcelForm><input id="expContent" name="content" type="text" /><input id="expfileName" name="fileName" type="text" /></form></div>');
    }
    var ExcelForm = objExpTemp.contentWindow.document.forms['ExcelForm'];
    var txtData = objExpTemp.contentWindow.document.getElementById('expContent');
    var txtFilename = objExpTemp.contentWindow.document.getElementById('expfileName');
    txtData.value = data;
    txtFilename.value = escape(tablename);
    ExcelForm.action = '../../ExcelTransfer/index';
    ExcelForm.method = 'POST';

    ExcelForm.submit();

    return;
}
//js时间比较(yyyy-mm-dd hh:mi:ss),前面比后面的时间大返回false,后面比前面时间大则返回true
function compareTime(startDate, endDate) {
    if (startDate.length > 0 && endDate.length > 0) {
        var startDateTemp = startDate.split(" ");
        var endDateTemp = endDate.split(" ");

        var arrStartDate = startDateTemp[0].split("-");
        var arrEndDate = endDateTemp[0].split("-");

        var arrStartTime = startDateTemp[1].split(":");
        var arrEndTime = endDateTemp[1].split(":");

        var allStartDate = new Date(arrStartDate[0], arrStartDate[1], arrStartDate[2], arrStartTime[0], arrStartTime[1], arrStartTime[2]);
        var allEndDate = new Date(arrEndDate[0], arrEndDate[1], arrEndDate[2], arrEndTime[0], arrEndTime[1], arrEndTime[2]);

        if (allStartDate.getTime() > allEndDate.getTime()) {
            return false;
        } else {
            return true;
        }
    } else {
        alert("时间不能为空");
        return false;
    }
}
//获取当前的日期时间 格式“yyyy-MM-dd HH:MM:SS”
function getNowFormatDate() {
    var date = new Date();
    var seperator1 = "-";
    var seperator2 = ":";
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
            + " " + date.getHours() + seperator2 + date.getMinutes()
            + seperator2 + date.getSeconds();
    return currentdate;
}
//js时间相差(yyyy-mm-dd)
function compareDate(startDate, endDate) {
    if (startDate.length > 0 && endDate.length > 0) {
        var startDateTemp = startDate.split(" ");
        var endDateTemp = endDate.split(" ");

        var arrStartDate = startDateTemp[0].split("-");
        var arrEndDate = endDateTemp[0].split("-");

        var day1 = (new Date).setFullYear(arrStartDate[0], arrStartDate[1], arrStartDate[2]);
        var day2 = (new Date).setFullYear(arrEndDate[0], arrEndDate[1], arrEndDate[2]);
        var number_of_days = (day2 - day1) / 86400000;

        return number_of_days;

    } else {
        alert("时间不能为空");
        return false;
    }
}


window.toDateFmt = function (val, f) {
    //    if (val != null) {
    //        var date = new Date(parseInt(val.replace("/Date(", "").replace(")/", ""), 10));
    //        //月份为0-11，所以+1，月份小于10时补个0
    //        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    //        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    //        return date.getFullYear() + "-" + month + "-" + currentDate;
    //    }

    //    return "";
    if (!val) {
        return '-';
    }
    if (isDatePart(val)) {
        return val;
    }
    var d;
    if (!f) f = "yyyy-MM-dd";
    //    if (!/\/Date\(\d+(\+\d+)?\)\//.test(val)) {
    //        d = new Date(val.replace(/-/g, "/"));
    //    } else {
    //        d = new Date(parseInt(/-?\d+/.exec(val)[0]));
    //    }
    d = new Date(parseInt(val.replace("/Date(", "").replace(")/", ""), 10));
    var vals = {
        "yyyy": d.getFullYear(),
        "MM": ("00" + (d.getMonth() + 1)).slice(-2),
        "dd": ("00" + d.getDate()).slice(-2),
        "HH": ("00" + d.getHours()).slice(-2),
        "mm": ("00" + d.getMinutes()).slice(-2),
        "ss": ("00" + d.getSeconds()).slice(-2)
    };
    for (key in vals) {
        f = f.replace(eval("/" + key + "/g"), vals[key]);
    }
    return f;
};

/***********************************************************************
* 判断一个字符串是否为合法的日期格式：YYYY-MM-DD
*/
function isDatePart(dateStr) {
    var parts;
    if (dateStr.indexOf("-") > -1) {
        parts = dateStr.split('-');
    } else if (dateStr.indexOf("/") > -1) {
        parts = dateStr.split('/');
    } else {
        return false;
    }
    if (parts.length < 3) {
        //日期部分不允许缺少年、月、日中的任何一项
        return false;
    }
    for (i = 0; i < 3; i++) {
        //如果构成日期的某个部分不是数字，则返回false
        if (isNaN(parts[i])) {
            return false;
        }
    }
    y = parts[0]; //年
    m = parts[1]; //月
    d = parts[2]; //日
    if (y > 3000) {
        return false;
    }
    if (m < 1 || m > 12) {
        return false;
    }
    switch (d) {
        case 29:
            if (m == 2) {
                //如果是2月份
                if ((y / 100) * 100 == y && (y / 400) * 400 != y) {
                    //如果年份能被100整除但不能被400整除 (即闰年)
                } else {
                    return false;
                }
            }
            break;
        case 30:
            if (m == 2) {
                //2月没有30日
                return false;
            }
            break;
        case 31:
            if (m == 2 || m == 4 || m == 6 || m == 9 || m == 11) {
                //2、4、6、9、11月没有31日
                return false;
            }
            break;
        default:
    }
    return true;
}


//_common.regx = {
//    email: /^[0-9a-zA-Z_\.\-]+@([0-9a-zA-Z_\-\.])+[\.]+[a-z]{2,4}$/,
//    float: /^(-?\d+)(\.\d+)?$/,
//    positivefloat: /^(\d+)(\.\d+)?$/,
//    int: /^[1-9]+[0-9]*]*$/,
//    int0: /^[0-9]+[0-9]*]*$/,
//    percentage: /^((\d|[123456789]\d)(\.\d+)?|100)$/,
//    idcard: /^(\d{18,18}|\d{15,15}|\d{17,17}(x|X))$/,
//    mobile: /^[0-9]\d{10}$/,
//    discount: /^(-?([0-9]\d{0,9})|0)(\.\d{1,2})?$/, //折扣值的金额
//    payment: /^[\w\u4e00-\u9fa5]+(\(\d+(\.\d+)?%\))$/,         //付款方式 一次性付款(99.99%)
//    money: /^(\d+)(\.\d{0,2})?$/,                         //货币金额
//    phone: /^\d{7,8}$/,         //电话号码7-8位(不带区号)
//    zip: /^\d{6}$/  //邮编6位
//};


if (!Array.prototype.filter) {
    Array.prototype.filter = function (fun /*, thisArg */) {
        "use strict";

        if (this === void 0 || this === null)
            throw new TypeError();

        var t = Object(this);
        var len = t.length >>> 0;
        if (typeof fun !== "function")
            throw new TypeError();

        var res = [];
        var thisArg = arguments.length >= 2 ? arguments[1] : void 0;
        for (var i = 0; i < len; i++) {
            if (i in t) {
                var val = t[i];

                // NOTE: Technically this should Object.defineProperty at
                //       the next index, as push can be affected by
                //       properties on Object.prototype and Array.prototype.
                //       But that method's new, and collisions should be
                //       rare, so use the more-compatible alternative.
                if (fun.call(thisArg, val, i, t))
                    res.push(val);
            }
        }

        return res;
    };
}

window.customer_status_option = [
    { value: '报备', lable: '报备' },
    { value: '报备有效', lable: '报备有效' },
    { value: '报备无效', lable: '报备无效' },
    { value: '报备失效', lable: '报备失效' },
    { value: '带看', lable: '带看' },
    { value: '带看失效', lable: '带看失效' },
    { value: '认筹', lable: '认筹' },
    { value: '大定', lable: '大定' },
    { value: '大定审核未通过', lable: '大定审核未通过' },
    { value: '大定审核已通过', lable: '大定审核已通过' },
    { value: '退定', lable: '退定' },
    { value: '成销', lable: '成销' },
    { value: '退房', lable: '退房' }
];
window.report_date_option = [
    { value: '报备', lable: '报备' },
    { value: '报备有效', lable: '报备有效' },
    { value: '报备无效', lable: '报备无效' },
    { value: '报备失效', lable: '报备失效' },
    { value: '带看', lable: '带看' },
    { value: '带看失效', lable: '带看失效' },
    { value: '大定提交', lable: '大定提交' },
    { value: '大定审核退回', lable: '大定审核退回' },
    { value: '大定审核通过', lable: '大定审核通过' },
    { value: '退定', lable: '退定' },
    { value: '成销', lable: '成销' },
    { value: '退房', lable: '退房' }
];
window.project_status_option = [{ value: '-1', label: '不限' },
    { value: '1', label: '是' },
    { value: '0', label: '否' }];

window.status_qd_option = [{ value: '-1', label: '不限' },
{ value: '1', label: '是' },
{ value: '0', label: '否' }];
window.crm_relative_status = [{ value: '不限', label: '不限' },
    { value: '是', label: '是' },
    { value: '否', label: '否' }];
window.project_partner_status = [{ value: '不限', label: '不限' },
    { value: '是', label: '是' },
    { value: '否', label: '否' }];

window.hzq_option = [{ value: '不限', label: '不限' },
{ value: '在', label: '是' },
{ value: '不在', label: '否' }];

Vue.prototype.toAmountFmt = function (val, num) {

    if (!val) {
        return '-';
    }
    var n = 2;
    if (num != undefined) n = num;
    if (n == 0) return Supremo_Common.ConvertToNum(val);
    var p = "";
    if (val < 0) {
        val = Math.abs(val);
        p = "-";
    }
    val = parseFloat((val + "").replace(/[^\d\.-]/g, "")).toFixed(n) + "";
    var l = val.split(".")[0].split("").reverse();
    r = val.split(".")[1];
    r = r == "00" ? ".00" : "." + r;
    var t = "";
    for (i = 0; i < l.length; i++) {
        t += l[i] + ((i + 1) % 3 == 0 && (i + 1) != l.length ? "," : "");
    }
    return p + t.split("").reverse().join("") + r;
};

Vue.prototype.toNumFmt = function (val) {
    if (val == 0) {
        return '-';
    }
    var l = (Math.round(parseFloat(val)) + "").split("").reverse();
    var t = "";
    for (i = 0; i < l.length; i++) {
        t += l[i] + ((i + 1) % 3 == 0 && (i + 1) != l.length ? "," : "");
    }
    return t.split("").reverse().join("");
};