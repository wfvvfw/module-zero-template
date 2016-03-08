(function () {
    $(function () {
        var fixedHeaderOffset = 0;
        if (App.getViewPort().width < App.getResponsiveBreakpoint('md')) {
            if ($('.page-header').hasClass('page-header-fixed-mobile')) {
                fixedHeaderOffset = $('.page-header').outerHeight(true);
            }
        } else if ($('.page-header').hasClass('navbar-fixed-top')) {
            fixedHeaderOffset = $('.page-header').outerHeight(true);
        }

        var table = $('#tbTenant').DataTable({
            paging: true,
            serverSide: true,
            "processing": true,
            "lengthMenu": [5, 10, 15, 30],
            "pagingType": "full_numbers",
            "dom": '<lB<t>ip>',
            "buttons": [
                { extend: 'copy', className: 'btn red btn-outline' },
                { extend: 'pdf', className: 'btn green btn-outline' },
                { extend: 'excel', className: 'btn yellow btn-outline ' },
                { extend: 'csv', className: 'btn purple btn-outline ' },
                { extend: 'colvis', className: 'btn dark btn-outline', text: 'Columns' }
            ],
            'ajax': {
                type: 'POST',
                url: abp.appPath + 'Tenants/GetList',//'@Url.Action("GetList")',
                dataSrc: function (json) {
                    console.log(json);
                    json.draw = json.result.draw;
                    json.recordsTotal = json.result.recordsTotal;
                    json.recordsFiltered = json.result.recordsFiltered;
                    return json.result.data;
                }
            },
            columns: [
                { "title":"id", "data": "id",visible:false},
                { "title":"租户", "data": "tenancyName" },
                { "title": "管理员", "data": "name" },
                { "title": "是否有效", "data": "isActive" },
                { "title":"操作","data": null }
            ],
            "columnDefs": [
                {
                    render: function (data, type, row) {
                        return '<a class="btn btn-sm btn-outline blue" href="#"  > Edit <i class="fa fa-edit"></i></a>'
                            + '<button class="btn btn-sm btn-outline red" data-crud="d" data-id="'+ row.id +'"> Delete <i class="fa fa-times"></i></button>'
                        ;
                    },
                    targets: 4
                }
            ],
            language: {
                url: '..' + abp.appPath + '/Metronic/assets/global/plugins/datatables/plugins/localisation/Chinese.json'
            },
            fixedHeader: {
                header: true,
                headerOffset: fixedHeaderOffset
            }
        });

        var _tenantService = abp.services.app.tenant;

        table.on('draw.dt', function() {
            $('[data-crud="d"]').confirmation({
                popout: true,
                singleton: true,
                title: "确定删除？",
                btnOkLabel: "ok",
                onConfirm: function () {
                    console.log('delete' + this.id);
                    _tenantService.deleteTenant(this.id).done(function () {
                        table.ajax.reload();
                    });
                    console.log(this);
                }
            });
        });

        //var _tenantService = abp.services.app.tenant;

        //var data = _tenantService.getTenants().done(function(data) {
            //    console.log(data);
            //});
            //console.log(data);
        //});

        

    });
})();