;(function($) {
    

     

    function show(n) {
        var _box = "box_" + n;
        var box = document.getElementById(_box);
        var text = box.innerHTML;
        var newBox = document.createElement("div");
        var btn = document.createElement("a");
        newBox.innerHTML = text.substring(0, 300);
        btn.innerHTML = text.length > 300 ? "...显示全部" : "";
        btn.href = "###";
        btn.onclick = function() {
            if (btn.innerHTML == "...显示全部") {
                btn.innerHTML = "收起";
                newBox.innerHTML = text;
            } else {
                btn.innerHTML = "...显示全部";
                newBox.innerHTML = text.substring(0, 300);
            }
        }
        box.innerHTML = "";
        box.appendChild(newBox);
        box.appendChild(btn);
    }
    for (var i = 0; i < 1; i++) {
        show(i);
    }

    // 关闭遮盖层
    function syntheticnew_dimmer() {
        $('.syntheticnew_dimmer').hide();
    }
    // 关闭反应条件
    function close_syntheticnew_slide() {
        $('.syntheticnew_slide').animate({
            'right': '-877px'
        }, syntheticnew_dimmer);
    }

    //  打开反应条件
    $('#box_test').on('click','.J_show_syntheticnew_slide',function(){
        $('.syntheticnew_dimmer').show();
        $('.syntheticnew_slide').animate({
            'right': '0px'
        });
    });

    //  关闭反应条件
    $('.J_close_syntheticnew_slide').on('click', function() {
        close_syntheticnew_slide();
    });

    // 阻止事件冒泡
    $(".J_syntheticnew_slide").on("click", function(e) {
        e.stopPropagation();
    });
    //点击其他地方关闭右侧菜单
    $(".syntheticnew_dimmer").on("click", function() {
        close_syntheticnew_slide();
    });
    //关闭屏蔽原因
    $(".J_shielding_dimmer").on("click", function() {
        $('.shielding_dimmer').parent('.dimmer').hide();
    });

    //打开屏蔽
    $(".J_shield").on("click", function() {
        $('.shielding_dimmer').parent('.dimmer').show();
    });

    //打开历史报价
     $('#box_test').on('click','.J_historical_offer_btn',function(){
        $('.historyPrice').parent('.dimmer').show();
    });
     
    //关闭历史报价
     $('.J_close_historyPrice').on('click',function(){
         $('.historyPrice').parent('.dimmer').hide();
    });

    //打开反应条件及步骤
    $(".J_condition_btn").on("click", function() {
        $('.reaction_dimmer').parent('.dimmer').show();
    });
    //关闭反应条件及步骤
    $(".J_close_sDataLists").on("click", function() {
        $('.reaction_dimmer').parent('.dimmer').hide();
    });
    

    // 点击tr，选中一行
    $(".J_select_tr").on("click", function() {
        $(this).find('.J_select_radio').iCheck('check');
    });

    //选择屏蔽原因
    $('.shielding_dimmer').on('click','a',function(){
        var self = $(this);
        self.hasClass('active') ? self.removeClass('active') : self.addClass('active');
    });


    // 1.获得节点长度
    // 2.


    // 错误信息提示，J_fruitless


    //   var data = {
    //     "list": [ {
    //         "name":"妞妞",
    //         "num": "11",
    //         "cas": "10:02:19"
    //     },{
    //         "name":"java",
    //         "num": "12g",
    //         "cas": "10:02:19"
    //     },{
    //         "name":"thml",
    //         "num": "114g",
    //         "cas": "10:02:19"
    //     },{
    //         "name":"模版",
    //         "num": "112g",
    //         "cas": "10:02:19"
    //     }]
    // };
    // //注册一个Handlebars模版，通过id找到某一个模版，获取模版的html框架
    // var myTemplate = Handlebars.compile($("#syntheticnew_template").html());

    // //将json对象用刚刚注册的Handlebars模版封装，得到最终的html，插入到基础table中。
    // $('#SyntheticSearch').empty();
    // console.log(myTemplate(data));
    // $('#SyntheticSearch').html(myTemplate(data));

  
   var a=new OrgNode();
   a.Description="aaa";
   a.Status="精确路线";
    var b=new OrgNode();
        b.Status="精确路线";
        b.Description="111";
    var b1=new OrgNode();
        b1.Status="智能分析";
        b1.Description="b1";
        b.Nodes.Add(b1);
    var b2=new OrgNode();
        b2.Status="智能分析";
        b2.Description="b2";
        b1.Nodes.Add(b2);
    var b3=new OrgNode();
        b3.Status="智能分析";
        b3.Description="b3";
        b2.Nodes.Add(b3);

    a.Nodes.Add(b);
    
    // var c=new OrgNode();
    //     c.Status="智能分析";
    //     c.Description="222";
    // a.Nodes.Add(c);
    // var d=new OrgNode();
    //     d.Status="精确路线" ;
    //     d.Description="333" ;  
    // c.Nodes.Add(d);
    // var e=new OrgNode();
    //     e.Status="精确路线";
    //     e.Description="444";
    // c.Nodes.Add(e);
    // var f=new OrgNode();
    //     f.Status="精确路线";
    //     f.Description="444";
    // c.Nodes.Add(f);  
    // var g=new OrgNode();
    //     g.Status="精确路线";
    //     g.Description="444";
    // c.Nodes.Add(g);
    // var g1=new OrgNode();
    //     g1.Status="精确路线";
    //     g1.Description="5555";
    // c.Nodes.Add(g1);


var OrgShows=new OrgShow(a);
    OrgShows.Top=25;  //设置顶距离
    OrgShows.Left=25; //设置左距离
    OrgShows.IntervalWidth=125; //设置节点间隔宽度
    OrgShows.IntervalHeight=0; //设置节点间隔高度
    OrgShows.ShowType=2;  //设置节点展示方式  1横向  2竖向
    // OrgShows.BoxHeight=180;  //设置节点默认高度
    //OrgShows.BoxWidth=100; //设置节点默认宽度
    //OrgShows.BoxTemplet="="<div id=\"{Id}\" style=\"font-size:12px;padding:5px 5px 5px 5px;border:thin solid orange;background-color:lightgrey; clear:left;float:left;text-align:center;position:absolute;\" title=\"{Description}\" ><a href=\"{Link}\">{Text}</a></div>";自定义节点模板
    // OrgShows.LineSize=1;  //设置线条大小
    // OrgShows.LineColor=2;  //设置线条颜色
    OrgShows.Run()



    
})(jQuery);
