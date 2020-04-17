var pagejs = function () {
    var Id = 0;

    var GetList = function ($this) {
        $this.loading = true;
        //var rqData = "pageIndex=" + $this.currentPage;
        //rqData += "&pageSize=" + $this.pageSize;
        var  rqData = "id=" + $("#pid").val();
        //rqData += "&unit_kind=" + $this.form.unit_kind;
        //rqData += "&code=" + $this.form.code;
        //rqData += "&unit_name=" + $this.form.unit_name;
        //rqData += "&price=" + $this.form.price;
        //rqData += "&status=" + $this.form.status;

        $.ajax({
            type: "POST",
            data: rqData,
            url: "/Unit/GetUnitGoodsList",
            dataType: "json",
        }).success(function (res) {
            if (res.BFlag == '10') {
                //$this.total = res.TData.dataCount;
                $this.tableData = res.TData.singleData.unit_goods_list;
                $this.tableDataSum = res.TData.singleData.unit_goods_list_sum;
            } else {
                $this.$msgbox({
                    title: '错误',
                    message: res.Msg,
                    type: 'error',
                    center: true
                });
            }
            $this.loading = false;
        }).error(function (xhr, status) {
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
                url: "/Unit/Delete_UnitGoodsList"
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

    var GetSummaries = function ($this, param) {
        var sums = [];
        param.columns.forEach(function (column, index) {
            if (index === 0) {
                sums[index] = '合计';
                return;
            }
            if (index === 4) {
                sums[index] = $this.toNumFmt($this.tableDataSum.count);
                return;
            }
            if (index === 5) {
                sums[index] = $this.toNumFmt($this.tableDataSum.price);
                return;
            }
            if (index === 6) {
                sums[index] = $this.toNumFmt($this.tableDataSum.sell_min_price);
                return;
            }
            if (index === 7) {
                sums[index] = $this.toNumFmt($this.tableDataSum.sell_max_price);
                return;
            }
            
        });
        return sums;
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
                formatDate: function (row, column, cellValue, index) {
                    return window.toDateFmt(cellValue);
                },
                onSubmit: function () {
                    this.currentPage = 1;
                    window.GetList(this);
                },
                JumpUrl: function (url) {
                    window.JumpUrl(url);
                },
                Add: function () {
                    window.Add(this);
                },
                getSummaries: function (param) {
                    return window.GetSummaries(this, param);
                },
                formatNum: function (row, column, cellValue, index) {
                    return this.toNumFmt(cellValue);
                },
                showUpdate: function (row) {
                    this.dialogFormVisible = true;
                    this.addForm.id = row.id;
                    this.addForm.goods_name = row.goods_name + "(" + row.goods_id+")";
                    this.addForm.goods_name_new = row.goods_name_new;
                    this.addForm.count = row.count;
                    this.addForm.price = row.price;
                    this.addForm.sell_min_price = row.sell_min_price;
                    this.addForm.sell_max_price = row.sell_max_price;
                    this.addForm.title = "编辑系列产品";
                },
                showAdd: function () {
                    this.dialogFormVisible = true;
                    this.addForm.id = "";
                    this.addForm.unit_id = "";
                    this.addForm.goods_name = "";
                    this.addForm.goods_name = "";
                    this.addForm.goods_name_new = "";
                    this.addForm.price = "";
                    this.addForm.count = "";
                    this.addForm.sell_min_price = "";
                    this.addForm.sell_max_price = "";
                    this.addForm.title = "添加系列产品";
                },
                clearAdd: function () {
                    this.addForm.id = "";
                    this.addForm.unit_id = "";
                    this.addForm.goods_name = "";
                    this.addForm.goods_name = "";
                    this.addForm.goods_name_new = "";
                    this.addForm.price = "";
                    this.addForm.count = "";
                    this.addForm.sell_min_price = "";
                    this.addForm.sell_max_price = "";
                },
                Delete: function (id) {
                    window.Delete(id, this);
                },
                querySearch: function (queryString, cb) {
                    $.ajax({
                        type: "POST",
                        data: "str=" + queryString,
                        url: "/Unit/GetGoodsListFromSql",
                        dataType: "json",
                    }).success(function (res) {
                        cb(res);
                    })

                },
            },
            mounted: function () {
                //初始化
                this.onSubmit();
            },
            filters: {
                //时间戳
                formatDate(time) {
                    return window.toDateFmt(time);
                },
            }
        });
    }
   
    //添加商品
    var Add = function ($this) {
        var goods_id = 0;
        if (!$this.addForm.goods_name) {
            $this.$msgbox({
                title: '错误',
                message: '请选择商品',
                type: 'error',
                center: true
            });
            return;
        } 
        if (!$this.addForm.goods_name_new) {
            $this.$msgbox({
                title: '错误',
                message: '请填写商品自定义名称',
                type: 'error',
                center: true
            });
            return;
        }

        if (!$this.addForm.count) {
            $this.$msgbox({
                title: '错误',
                message: '请填加入数量',
                type: 'error',
                center: true
            });
            return;
        }

        if (!$this.addForm.price) {
            $this.$msgbox({
                title: '错误',
                message: '请填估计成本',
                type: 'error',
                center: true
            });
            return;
        }

       
    

        if (!$this.addForm.id) {
            Id = 0;
        } else {
            Id = $this.addForm.id;
        }


        var paras = {};
        paras.id = Id;
    
        //paras.goods_id = $this.addForm.goods_id;
        //paras.goods_name = $this.addForm.goods_name;
        paras.id = Id;
        paras.unit_id = $("#pid").val();
        paras.goods_name = $this.addForm.goods_name;

        paras.goods_name_new = $this.addForm.goods_name_new;
        paras.count = $this.addForm.count;
        paras.price = $this.addForm.price;
        paras.sell_min_price = $this.addForm.sell_min_price;
        paras.sell_max_price = $this.addForm.sell_max_price;
        
        $.ajax({
            type: "POST",
            data: "formVals=" + JSON.stringify(paras),
            url: "/Unit/AddUnitGoods",
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
            tableData: [{}],
            tableDataSum: {},
            input: '',
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
            addForm: {
                id: 0,
                unit_id: "",
                goods_name: "",
                goods_name_new: "",
                count: "",
                price: "",
                goods_name_new: "",
                sell_max_price: "",
                sell_min_price: "",
            }
        };
        return model;
    }

    return {
        init: function () {
            window.GetModel = GetModel;
            window.GetList = GetList;
            window.Add = Add;
            window.Delete = Delete;
            window.GetSummaries = GetSummaries;
            handle();

        }
    };
}();