/*inputbox初始化样式*/
//$(".Text_long input").live({
//    focus: function () {
//        var classname = $(this).parent().attr("class");
//        classname += '_focus';
//        $(this).parent().attr("class", classname);
//    }
//});

$("document").on('focus', '.Text_long input', function () {
    var classname = $(this).parent().attr("class");
    classname += '_focus';
    $(this).parent().attr("class", classname);
});

//$(".Text_long_focus input").live({
//    blur: function () {
//        var classname = $(this).parent().attr("class");
//        classname = classname.replace("_focus", "");
//        $(this).parent().attr("class", classname);
//    }
//});

$("document").on('blur', '.Text_long_focus input', function () {
    var classname = $(this).parent().attr("class");
    classname = classname.replace("_focus", "");
    $(this).parent().attr("class", classname);
});

//$(".Text_middle input").live({
//    focus: function () {
//        var classname = $(this).parent().attr("class");
//        classname += '_focus';
//        $(this).parent().attr("class", classname);
//    }
//});

$("document").on('focus', '.Text_middle input', function () {
    var classname = $(this).parent().attr("class");
    classname += '_focus';
    $(this).parent().attr("class", classname);
});

//$(".Text_middle_focus input").live({
//    blur: function () {
//        var classname = $(this).parent().attr("class");
//        classname = classname.replace("_focus", "");
//        $(this).parent().attr("class", classname);
//    }
//});

$("document").on('blur', '.Text_middle_focus input', function () {
    var classname = $(this).parent().attr("class");
    classname = classname.replace("_focus", "");
    $(this).parent().attr("class", classname);
});

//$(".Text_short input").live({
//    focus: function () {
//        var classname = $(this).parent().attr("class");
//        classname += '_focus';
//        $(this).parent().attr("class", classname);
//    }
//});

$("document").on('focus', '.Text_short input', function () {
    var classname = $(this).parent().attr("class");
    classname += '_focus';
    $(this).parent().attr("class", classname);
});

//$(".Text_short_focus input").live({
//    blur: function () {
//        var classname = $(this).parent().attr("class");
//        classname = classname.replace("_focus", "");
//        $(this).parent().attr("class", classname);
//    }
//});

$("document").on('blur', '.Text_short_focus input', function () {
    var classname = $(this).parent().attr("class");
    classname = classname.replace("_focus", "");
    $(this).parent().attr("class", classname);
});