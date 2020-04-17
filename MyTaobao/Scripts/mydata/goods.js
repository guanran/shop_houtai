var pagejs = function () {
    var goodId = 0;

    var GetList = function ($this) {
        $this.loading = true;
        var rqData = "pageIndex=" + $this.currentPage;
        rqData += "&pageSize=" + $this.pageSize;
        rqData += "&type=" + $this.form.type;
        rqData += "&goodsName=" + $this.form.goodsName;
        rqData += "&minPrice=" + $this.form.minPrice;
        rqData += "&maxPrice=" + $this.form.maxPrice;
        rqData += "&sell_min_price=" + $this.form.sell_min_price;
        rqData += "&sell_max_price=" + $this.form.sell_max_price;
        //rqData += "&status=" + $this.form.status;

        $.ajax({
            type: "POST",
            data: rqData,
            url: "/Goods/GoodsList",
            dataType: "json",
        }).success(function (res) {
            if (res.BFlag == '10') {
                $this.total = res.TData.dataCount;
                $this.tableData = res.TData.data;

            } else {
                $this.$msgbox({
                    title: '错误',
                    message: res.Msg,
                    type: 'error',
                    center: true
                });
            }
            $this.loading = false;
        }).error(function(xhr, status){
            $this.loading = false;
        })
    }


    var Delete = function (id, $this) {
        $this.$confirm('确认删除吗?', '提示', {
            confirmButtonText: '确定',
            cancelButtonText: '取消',
            type: 'warning'
        }).then(function () {
            $this.formLoading = true;
            var rqData = "id=" + id;
            $.ajax({
                type: "POST",
                data: rqData,
                url: "/Goods/DeleteGoods"
            }).success(function (res) {
                if (res.BFlag == '10') {
                    $this.$msgbox({
                        title: '成功',
                        message: res.Msg,
                        type: 'success',
                        center: true
                    });
                    window.GetList($this);
                } else {
                    $this.$msgbox({
                        title: '错误',
                        message: res.message,
                        type: 'error',
                        center: true
                    });
                }
                $this.formLoading = false;
            }).error(function (xhr, status) {
                $this.formLoading = false;
            });
        });                 
    }

    var Copy = function (url, $this) {
        var flag = copyText(url); //传递文本
        alert(flag ? "复制成功！" : "复制失败！");

        //var copyText = $("#test") ；//获取对象
        //    copyText.select();//选择
        //document.execCommand("Copy");//执行复制
        //alert("复制成功！");
    }

    function copyText(text) {
        var textarea = document.createElement("input");//创建input对象
        var currentFocus = document.activeElement;//当前获得焦点的元素
        document.body.appendChild(textarea);//添加元素
        textarea.value = text;
        textarea.focus();
        if (textarea.setSelectionRange)
            textarea.setSelectionRange(0, textarea.value.length);//获取光标起始位置到结束位置
        else
            textarea.select();
        try {
            var flag = document.execCommand("copy");//执行复制
        } catch (eo) {
            var flag = false;
        }
        document.body.removeChild(textarea);//删除元素
        currentFocus.focus();
        return flag;
    }

    var handle = function () {
        new Vue({
            el: "#app",
            data: function () {
                return window.GetModel();
            },
            methods: {
                handleSizeChange: function (val) {
                    console.log('每页' + val + '条');
                    this.pageSize = val;
                    this.currentPage = 1;
                    window.GetList(this);
                },
                handleCurrentChange: function (val) {
                    console.log('当前页:' + val);
                    this.currentPage = val;
                    window.GetList(this);
                },
                onSubmit: function () {
                    this.currentPage = 1;
                    window.GetList(this);
                },
                JumpUrl: function (url) {
                    window.JumpUrl(url);
                },
                Copy: function (url) {
                    window.Copy(url,this);
                },
                AddGoods: function () {
                    window.AddGoods(this);
                },

                showUpdateGoods: function (row) {
                    this.dialogFormVisible = true;
                    this.addGoodsForm.id = row.id;
                    this.addGoodsForm.topType = row.topType;
                    this.addGoodsForm.type = row.type;
                    this.addGoodsForm.goodsName = row.goodsName;
                    this.addGoodsForm.describe = row.describe;
                    this.addGoodsForm.minPrice = row.minPrice;
                    this.addGoodsForm.maxPrice = row.maxPrice;
                    this.addGoodsForm.sell_min_price = row.sell_min_price;
                    this.addGoodsForm.sell_max_price = row.sell_max_price;
                    
                    this.addGoodsForm.url = row.url;
                    this.addGoodsForm.title = "编辑产品";
                },
                showAddGoods: function(){
                    this.dialogFormVisible = true;
                    //this.addGoodsForm.topType = "";
                    //this.addGoodsForm.type = "";
                    //this.addGoodsForm.goodsName = "";
                    //this.addGoodsForm.describe = "";
                    //this.addGoodsForm.minPrice = "";
                    //this.addGoodsForm.maxPrice = "";
                    //this.addGoodsForm.url = "";
                    this.addGoodsForm.id="";
                    this.addGoodsForm.title = "添加产品";
                },
                clearAddGoods: function () {
                    this.addGoodsForm.topType = "";
                    this.addGoodsForm.type = "";
                    this.addGoodsForm.goodsName = "";
                    this.addGoodsForm.describe = "";
                    this.addGoodsForm.minPrice = "";
                    this.addGoodsForm.maxPrice = "";
                    this.addGoodsForm.sell_min_price = "";
                    this.addGoodsForm.sell_max_price = "";
                    this.addGoodsForm.url = "";
                },
                Delete: function (id) {
                    window.Delete(id, this);
                },
            },
            mounted: function () {
                //初始化
                this.onSubmit();
            }
        });
    }

    var JumpUrl = function (url) {
        window.location.href = url;
    }
    //添加商品
    var AddGoods = function ($this) {
        if (!$this.addGoodsForm.topType) {
            $this.$msgbox({
                title: '错误',
                message: '请填写产品大类',
                type: 'error',
                center: true
            });
            return;
        }
        if (!$this.addGoodsForm.type) {
            $this.$msgbox({
                title: '错误',
                message: '请填写产品种类',
                type: 'error',
                center: true
            });
            return;
        }

        if (!$this.addGoodsForm.goodsName) {
            $this.$msgbox({
                title: '错误',
                message: '请填写产品名称',
                type: 'error',
                center: true
            });
            return;
        }

        if (!$this.addGoodsForm.url) {
            $this.$msgbox({
                title: '错误',
                message: '请填写产品链接',
                type: 'error',
                center: true
            });
            return;
        }

        if (!$this.addGoodsForm.id) {
            goodId = 0;
        } else {
            goodId = $this.addGoodsForm.id;
        }


        var paras = {};
        paras.id = goodId;
        paras.topType = $this.addGoodsForm.topType;
        paras.type = $this.addGoodsForm.type;
        paras.goodsName = $this.addGoodsForm.goodsName;
        paras.describe = $this.addGoodsForm.describe;
        paras.minPrice = $this.addGoodsForm.minPrice;
        paras.maxPrice = $this.addGoodsForm.maxPrice;
        paras.sell_min_price = $this.addGoodsForm.sell_min_price;
        paras.sell_max_price = $this.addGoodsForm.sell_max_price;

        paras.url = escape($this.addGoodsForm.url);


        $.ajax({
            type: "POST",
            data: "formVals=" + JSON.stringify(paras),
            url: "/Goods/AddGoods",
            dataType: "json",
        }).success(function (res) {
            $this.dialogFormVisible = false;
            if (res.BFlag == '10') {
                $this.$msgbox({
                    title: '成功',
                    message: '添加成功',
                    type: 'success',
                    center: true
                });
            } else {
                $this.$msgbox({
                    title: '错误',
                    message: res.Msg,
                    type: 'error',
                    center: true
                });
            }
            $this.onSubmit();
        }).error(function (xhr, status) {

        });
    }
    //初始化参数
    var GetModel = function () {
        var model = {
            tableData: [],
            input: '',
            form: {
                type: '',
                goodsName: '',
                minPrice: '',
                maxPrice: '',
                sell_min_price: '',
                sell_max_price: '',
                
                status: '-1'
            },
            pageSizes: [15, 30, 45, 60],
            pageSize: 15,
            currentPage: 1,
            total: 0,
            loading: false,
            dialogFormVisible: false,
            select_loading: false,
            formLoading: false,
            tableLoading: false,
            formLabelWidth: '100px',
            addGoodsForm: {
                topType :"",
                type :"",
                goodsName: "",
                describe: "",
                minPrice: "",
                maxPrice: "",
                sell_min_price: '',
                sell_max_price: '',
                url: ""
            }
        };
        return model;
    }

    return {
        init: function () {
            window.GetList = GetList;
            window.GetModel = GetModel;
            window.JumpUrl = JumpUrl;
            window.AddGoods = AddGoods;
            window.Delete = Delete;
            window.Copy = Copy;
            handle();
        }
    };
}();