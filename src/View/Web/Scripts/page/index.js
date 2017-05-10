;(function($) {


    var index_main = {
        $window          : $(window),
        $index_page  	 : $('.index_page'),
        $J_arrow         : $('.J_arrow'),
        $J_index_dimmer  : $('.J_index_dimmer'),
        $J_desktop_page  : $('.J_desktop_page'),
        $J_index_seach   : $('.J_index_seach'),
        $header          : $('.header'),
        $header2         : $('.header2'),
        $J_goback        : $('.J_goback'),
        change_size: function() {
            var self = this;
            self.$index_page.css({
                height: self.$window.height() - 42
            });
        },
        init: function() {
            var self = this;
            self.change_size();

            self.$window.resize(function(event) {
                self.change_size();
            });
            self.$J_arrow.on('click', function(event) {
            	self.change_size();
                if (self.$J_desktop_page.hasClass('desktop_page_active')) {
                    self.$J_index_dimmer.css({
                        'margin-top': '0'
                    });
                    self.$J_index_seach.show();
                     // 替换头部菜单
                    self.$header.show();
                    self.$header2.hide();
                    self.$J_goback.hide();
                    self.$J_desktop_page.removeClass('desktop_page_active');

                } else {
                    self.$J_index_dimmer.css({
                        'transition': 'all 1.3s',
                        'margin-top': '-100%'
                    });
                    self.$J_index_seach.hide();
                    // 替换头部菜单
                    self.$header.hide();
                    self.$header2.show();
                    self.$J_goback.show(1200);
                    self.$index_page.css({
                        height: self.$window.height() - 72,
                        'padding-top':'30px'
                    });
                    // this_i.addClass('active'); 
                    self.$J_desktop_page.addClass('desktop_page_active'); 
                }
            });
            // 箭头返回搜索
            self.$J_goback.on('click',function(){
                 self.change_size();
            	if (self.$J_desktop_page.hasClass('desktop_page_active')) {
                    self.$J_goback.hide();
                      self.$J_index_dimmer.css({
                        'margin-top': '0'
                    });
                    self.$index_page.css({
                        height: self.$window.height() - 42,
                        'padding-top':'0'
                    });
                    self.$J_index_seach.show();
                    // this_i.removeClass('active');
                     // 替换头部菜单
                     self.$header2.hide();
                    self.$header.show();
                    self.$J_desktop_page.removeClass('desktop_page_active');
                }
            });
            // 按钮展开结构式搜索
            $('.J_search_draw').on('click',function(){
                 if (!self.$J_desktop_page.hasClass('desktop_page_active')) {
                  self.$J_index_dimmer.css({
                        'transition': 'all 1.3s',
                        'margin-top': '-100%'
                    });
                    self.$J_index_seach.hide();
                    // 替换头部菜单
                    self.$header.hide();
                    self.$header2.show();
                    self.$J_goback.show(1200);
                    self.$index_page.css({
                        height: self.$window.height() - 72,
                        'padding-top':'30px'
                    });
                    self.$J_desktop_page.addClass('desktop_page_active'); 
                }
            });

        }
    }
    index_main.init();

})(jQuery);
