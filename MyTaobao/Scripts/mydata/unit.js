var pagejs = function () {
    var Id = 0;
    var GetList = function ($this) {
        $this.loading = true;
        var rqData = "pageIndex=" + $this.currentPage;
        rqData += "&pageSize=" + $this.pageSize;
        rqData += "&unit_kind=" + $this.form.unit_kind;
        rqData += "&code=" + $this.form.code;
        rqData += "&unit_name=" + $this.form.unit_name;
        rqData += "&price=" + $this.form.price;
        //rqData += "&status=" + $this.form.status;

        $.ajax({
            type: "POST",
            data: rqData,
            url: "/Unit/GetList",
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
                url: "/Unit/Delete"
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
              
                Add: function () {
                    window.Add(this);
                },
                showUpdate: function (row) {
                    this.dialogFormVisible = true;
                    this.addForm.id = row.id;
                    this.addForm.code = row.code;
                    this.addForm.unit_kind = row.unit_kind;
                    this.addForm.unit_name = row.unit_name;
                    this.addForm.count = row.count;
                    this.addForm.price = row.price;
                    this.addForm.begin_time = window.toDateFmt(row.begin_time);
                    this.addForm.end_time = window.toDateFmt(row.end_time);
                    this.addForm.title = "编辑系列";
                },
                showAdd: function () {
                    this.dialogFormVisible = true;
                    //this.addGoodsForm.topType = "";
                    //this.addGoodsForm.type = "";
                    //this.addGoodsForm.goodsName = "";
                    //this.addGoodsForm.describe = "";
                    //this.addGoodsForm.minPrice = "";
                    //this.addGoodsForm.maxPrice = "";
                    //this.addGoodsForm.url = "";
                    this.addForm.id = "";
                    this.addForm.title = "添加系列";
                },
                showCopy: function (row) {
                    this.dialogFormVisible2 = true;
                    this.addForm2.id = row.id;
                    this.addForm2.code = row.code;
                    this.addForm2.unit_kind = row.unit_kind;
                    this.addForm2.unit_name = row.unit_name;
                    this.addForm2.title = "复制系列";
                },
                Copy: function () {
                    window.Copy(this);
                },
                clearAdd: function () {
                    this.addForm.code = "";
                    this.addForm.unit_kind = "";
                    this.addForm.unit_name = "";
                    this.addForm.count = "";
                    this.addForm.price = "";
                    this.addForm.begin_time = "";
                    this.addForm.end_time = "";
                },
                Delete: function (id) {
                    window.Delete(id, this);
                },
                Create: function (row) {
                    if (row.count == row.goods_num) {
                        window.Create(row.id, this);
                    } else {
                        this.$msgbox({
                            title: '错误',
                            message: '数量不满足',
                            type: 'error',
                            center: true
                        });
                        return;
                    }
                   
                },
                jumpUrl: function (url) {
                    window.JumpUrl(url);
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

    var Create = function (id, $this) {
        $this.$confirm('确认生成吗?', '提示', {
            confirmButtonText: '确定',
            cancelButtonText: '取消',
            type: 'warning'
        }).then(function () {
            $this.formLoading = true;
            var rqData = "id=" + id;
            $.ajax({
                type: "POST",
                data: rqData,
                url: "/Unit/Create"
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
  
    //添加商品
    var Add = function ($this) {
        if (!$this.addForm.code) {
            $this.$msgbox({
                title: '错误',
                message: '请填写系列编号',
                type: 'error',
                center: true
            });
            return;
        }
        if (!$this.addForm.unit_kind) {
            $this.$msgbox({
                title: '错误',
                message: '请填写系列类型',
                type: 'error',
                center: true
            });
            return;
        }

        if (!$this.addForm.unit_name) {
            $this.$msgbox({
                title: '错误',
                message: '请填写系列名称',
                type: 'error',
                center: true
            });
            return;
        }

        if (!$this.addForm.count) {
            $this.$msgbox({
                title: '错误',
                message: '请填写发售量',
                type: 'error',
                center: true
            });
            return;
        }

        if (!$this.addForm.price) {
            $this.$msgbox({
                title: '错误',
                message: '请填写发售单价',
                type: 'error',
                center: true
            });
            return;
        }

        if (!$this.addForm.begin_time) {
            $this.$msgbox({
                title: '错误',
                message: '请选择开始时间',
                type: 'error',
                center: true
            });
            return;
        }

        if (!$this.addForm.end_time) {
            $this.$msgbox({
                title: '错误',
                message: '请选择结束时间',
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
        paras.code = $this.addForm.code;
        paras.unit_kind = $this.addForm.unit_kind;
        paras.unit_name = $this.addForm.unit_name;
        paras.count = $this.addForm.count;
        paras.price = $this.addForm.price;
        paras.begin_time = $this.addForm.begin_time;
        paras.end_time = $this.addForm.end_time;


        $.ajax({
            type: "POST",
            data: "formVals=" + JSON.stringify(paras),
            url: "/Unit/Add",
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

    var Copy = function ($this) {
        if (!$this.addForm2.code) {
            $this.$msgbox({
                title: '错误',
                message: '请填写系列编号',
                type: 'error',
                center: true
            });
            return;
        }
        if (!$this.addForm2.unit_kind) {
            $this.$msgbox({
                title: '错误',
                message: '请填写系列类型',
                type: 'error',
                center: true
            });
            return;
        }

        if (!$this.addForm2.unit_name) {
            $this.$msgbox({
                title: '错误',
                message: '请填写系列名称',
                type: 'error',
                center: true
            });
            return;
        }
    

        if (!$this.addForm2.id) {
            Id = 0;
        } else {
            Id = $this.addForm2.id;
        }


        var paras = {};
        paras.id = Id;
        paras.code = $this.addForm2.code;
        paras.unit_kind = $this.addForm2.unit_kind;
        paras.unit_name = $this.addForm2.unit_name;

        $.ajax({
            type: "POST",
            data: "formVals=" + JSON.stringify(paras),
            url: "/Unit/Copy",
            dataType: "json",
        }).success(function (res) {
            $this.dialogFormVisible2 = false;
            if (res.BFlag == '10') {
                $this.$msgbox({
                    title: '成功',
                    message: '复制成功',
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


    var JumpUrl = function (url) {
        window.location.href = url;
    }


    //初始化参数
    var GetModel = function () {
        var model = {
            tableData: [],
            input: '',
            form: {
                code: '',
                unit_kind: '',
                unit_name: '',
                price: ''
            },
            pageSizes: [15, 30, 45, 60],
            pageSize: 15,
            currentPage: 1,
            total: 0,
            loading: false,
            dialogFormVisible: false,
            dialogFormVisible2: false,
            select_loading: false,
            formLoading: false,
            tableLoading: false,
            formLabelWidth: '100px',
            addForm: {
                id:0,
                code: "",
                unit_kind: "",
                unit_name: "",
                count: "",
                price: "",
                begin_time: "",
                end_time: ""
            },
            addForm2: {
                id:0,
                code: "",
                unit_kind: "",
                unit_name: "",
            },

        };
        return model;
    }

  

    return {
        init: function () {
            window.GetList = GetList;
            window.GetModel = GetModel;
            window.JumpUrl= JumpUrl;
            window.Add = Add;
            window.Delete = Delete;
            window.Create = Create;
            window.Copy = Copy;
            handle();

        }
    };
}();