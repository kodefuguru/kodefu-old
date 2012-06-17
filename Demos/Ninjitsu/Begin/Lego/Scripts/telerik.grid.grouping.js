(function($) {
    var $t = $.telerik;
    var dropClueOffsetTop = 3;
    var dropClueOffsetLeft = 0;
    var dragClueOffset = 4;

    $t.grouping = {};

    $t.grouping.initialize = function(grid) {
        $.extend(grid, $t.grouping.implementation);
        grid.$groupDropClue = $('<div class="t-grouping-dropclue"/>');

        grid.$groupHeader = $('.t-grouping-header', grid.element);

        $('.t-header .t-link, .t-grouping-header .t-link', grid.element)
            .live('mousedown', $t.delegate(grid, grid.waitForDrag))
            .live('dragstart', function(e) { e.preventDefault() }); //cancel default drag in IE

        if (grid.isAjax()) {

            $('.t-grouping-header .t-button', grid.element).live('click', function(e) {
                e.preventDefault();

                grid.unGroup($(this).parent().text());
            });

            $('.t-grouping-header .t-link', grid.element).live('click', function(e) {
                e.preventDefault();
                var group = grid.groupFromTitle($(this).parent().text());
                group.order = group.order == 'asc' ? 'desc' : 'asc';
                grid.group(group.title);
            });
        }

        $('.t-group-indicator', grid.element)
            .live('mouseenter', function() {
                grid.$currentGroupItem = $(this);
            })
            .live('mouseleave', function() {
                grid.$currentGroupItem = null;
            });

        $('.t-grouping-row .t-collapse, .t-grouping-row .t-expand', grid.element)
            .live('click', function(e) {
                e.preventDefault();
                var $tr = $(this).closest('tr');
                if ($(this).hasClass('t-collapse'))
                    grid.collapseGroup($tr);
                else
                    grid.expandGroup($tr);
            });
    }

    $t.grouping.implementation = {
        moveClue: function(e) {
            this.$dragClue.css({
                left: e.pageX + dragClueOffset, /* 4px offset*/
                top: e.pageY + dragClueOffset
            });

            if ($.contains(this.$groupHeader[0], e.target) || this.$groupHeader[0] == e.target) {
                var groupIndicators = $.map(this.$groupHeader.find('.t-group-indicator'), function(group) {
                    var $group = $(group);
                    var left = $group.offset().left;
                    return { left: left, right: left + $group.outerWidth(), $group: $group };
                });

                if (!groupIndicators.length) {
                    this.$groupDropClue.css({ top: dropClueOffsetTop, left: dropClueOffsetLeft }).appendTo(this.$groupHeader);
                    return;
                }

                var firstGroupIndicator = groupIndicators[0];
                var lastGroupIndicator = groupIndicators[groupIndicators.length - 1];
                var leftMargin = parseInt(firstGroupIndicator.$group.css('marginLeft'));
                var rightMargin = parseInt(firstGroupIndicator.$group.css('marginRight'));

                var currentGroupIndicator = $.grep(groupIndicators, function(g) {
                    return e.pageX >= g.left - leftMargin - rightMargin && e.pageX <= g.right;
                })[0];

                if (!currentGroupIndicator && firstGroupIndicator && e.pageX < firstGroupIndicator.left) {
                    currentGroupIndicator = firstGroupIndicator;
                }

                if (currentGroupIndicator)
                    this.$groupDropClue.css({ top: dropClueOffsetTop, left: currentGroupIndicator.$group.position().left - leftMargin + dropClueOffsetLeft })
                        .insertBefore(currentGroupIndicator.$group);
                else
                    this.$groupDropClue.css({ top: dropClueOffsetTop, left: lastGroupIndicator.$group.position().left + lastGroupIndicator.$group.outerWidth() + rightMargin + dropClueOffsetLeft })
                                   .appendTo(this.$groupHeader);
            } else {
                this.$groupDropClue.remove();
            }
        },

        columnIndexByTitle: function(title) {
            return this.$columns().index($('th:contains("' + title + '")', this.element));
        },

        groupFromTitle: function(title) {
            return $.grep(this.groups, function(g) { return g.title == title; })[0];
        },

        expandGroup: function(group) {
            var $group = $(group);
            var depth = $group.find('.t-groupcell').length;

            $group.find('~ tr').each($.proxy(function(i, tr) {
                var $tr = $(tr);
                var offset = $tr.find('.t-groupcell').length;
                if (offset <= depth)
                    return false;

                if (offset == depth + 1) {
                    $tr.show();

                    if ($tr.hasClass('t-grouping-row') && $tr.find('.t-icon').hasClass('t-collapse'))
                        this.expandGroup($tr);
                }

            }, this));

            $group.find('.t-icon').addClass('t-collapse').removeClass('t-expand');
        },

        collapseGroup: function(group) {
            var $group = $(group);
            var depth = $group.find('.t-groupcell').length;

            $group.find('~ tr').each(function() {
                var $tr = $(this);
                var offset = $tr.find('.t-groupcell').length;
                if (offset <= depth)
                    return false;

                $tr.hide();
            });
            $group.find('.t-icon').addClass('t-expand').removeClass('t-collapse');
        },

        toggleGroup: function(element) {
            var $group = $(element);
            var depth = $group.find('.t-groupcell').length;
            $group.find('~ tr').each(function() {
                var $tr = $(this);
                if ($tr.hasClass('t-grouping-row')) {
                    if ($tr.find('.t-groupcell').length <= depth)
                        return false;
                }
                $tr.toggle();
            });

            var $icon = $group.find('.t-icon');
            $icon.toggleClass('t-collapse').toggleClass('t-expand');
        },

        group: function(title, position) {
            if (this.groups.length == 0 && this.isAjax())
                this.$groupHeader.empty();

            var group = $.grep(this.groups, function(group) {
                return group.title == title;
            })[0];

            if (!group) {
                var column = this.columns[this.columnIndexByTitle(title)];
                group = { order: 'asc', member: column.member, title: title };
                this.groups.push(group);
            }

            if (position >= 0) {
                this.groups.splice($.inArray(group, this.groups), 1);
                this.groups.splice(position, 0, group);
            }

            this.groupBy = $.map(this.groups, function(g) { return g.member + '-' + g.order; }).join('~')

            if (!this.isAjax()) {
                location.href = $t.formatString(unescape(this.urlFormat),
                    this.currentPage, this.orderBy || '~', escape(this.groupBy) || '~', escape(this.filterBy) || '');
            } else {
                var $groupItem = this.$groupHeader.find('div:contains("' + title + '")');
                if ($groupItem.length == 0) {
                    var html = new $.telerik.stringBuilder()
                        .cat('<div class="t-group-indicator">')
                            .cat('<a href="#" class="t-link"><span class="t-icon" />').cat(title).cat('</a>')
                            .cat('<a class="t-button t-state-default"><span class="t-icon t-delete" /></a>')
                        .cat('</div>')
                    .string();
                    $groupItem = $(html).appendTo(this.$groupHeader);
                }

                if (this.$groupDropClue.is(':visible'))
                    $groupItem.insertBefore(this.$groupDropClue);

                $groupItem
                    .find('.t-link .t-icon')
                    .toggleClass('t-arrow-up-small', group.order == 'asc')
                    .toggleClass('t-arrow-down-small', group.order == 'desc');

                this.ajaxRequest();
            }
        },

        unGroup: function(title) {
            var group = this.groupFromTitle(title);
            this.groups.splice($.inArray(group, this.groups), 1);

            if (this.groups.length == 0)
                this.$groupHeader.html("Drag a column header and drop it here to group by that column");

            this.groupBy = $.map(this.groups, function(g) { return g.member + '-' + g.order; }).join('~');

            if (!this.isAjax()) {
                location.href = $t.formatString(unescape(this.urlFormat),
                    this.currentPage, this.orderBy || '~', escape(this.groupBy) || '~', escape(this.filterBy) || '');
            } else {
                this.$groupHeader.find('div:contains("' + group.title + '")').remove();
                this.ajaxRequest();
            }
        },

        startDrag: function(e) {
            var left = this.hittestCorrdinates.left - e.pageX;
            var top = this.hittestCorrdinates.top - e.pageY;
            var distance = Math.sqrt((top * top) + (left * left));

            if (distance > dragClueOffset) {
                this.$dragClue = this.$draggedElement
                        .clone(true)
                        .wrap('<div class="t-header t-drag-clue" />').parent()
                        .css({
                            position: 'absolute',
                            left: e.pageX + dragClueOffset,
                            top: e.pageY + dragClueOffset
                        })
                        .appendTo(document.body);

                $(document)
                    .unbind('mousemove.grid')
                    .bind('mousemove.grid', $.proxy(this.moveClue, this));
            }
        },

        stopDrag: function(e) {
            if (this.$dragClue) {
                // header has been dragged

                var groupingHeader = $(e.target).parents().andSelf().filter('.t-grouping-header');
                var title = this.$draggedElement.text();
                var columnIndex = this.columnIndexByTitle(title);
                var group = this.groupFromTitle(title);
                var groupIndex = $.inArray(group, this.groups);

                if (groupingHeader.length > 0) {
                    var position = this.$groupHeader.find('div').index(this.$groupDropClue);
                    var delta = groupIndex - position;
                    if (!group || (delta != 0 && delta != -1))
                        this.group(title, position);
                } else if (this.$draggedElement.parent().is('.t-group-indicator')) {
                    this.unGroup(title);
                }

                this.$dragClue.remove();

                this.$dragClue = null;

                this.$groupDropClue.remove();
            }

            $(document)
                .unbind('mousemove.grid')
                .unbind('mousemove.grid')
                .unbind('mouseup.grid');
        },

        waitForDrag: function(e, element) {
            var $target = $(element);

            if ($target.is('.t-grid-filter, .t-filter'))
                return;

            var text = $target.text();

            var group = $.grep(this.groups, function(group) {
                return group.title == text;
            })[0];

            if (group && $target.parent().is('.t-header'))
                return;

            e.preventDefault();

            this.$draggedElement = $target;

            this.hittestCorrdinates = {
                left: e.pageX,
                top: e.pageY
            };

            $(document).bind('mousemove.grid', $.proxy(this.startDrag, this))
                       .bind('mouseup.grid', $.proxy(this.stopDrag, this));
        },

        normalizeColumns: function() {
            var groups = this.groups.length;
            var colspan = groups + this.columns.length;
            var $cols = $('table:first col', this.element);
            var diff = colspan - $cols.length;
            if (diff == 0) return;

            if (diff > 0) {
                $(new $t.stringBuilder().rep('<col class="t-groupcol" />', diff).string())
                        .prependTo($('colgroup', this.element))
                $(new $t.stringBuilder().rep('<th class="t-groupcell t-header" />', diff).string())
                    .insertBefore($('th.t-header:first', this.element));

            } else {
                $('th:lt(' + Math.abs(diff) + ')', this.element).remove();
                $('table', this.element).find('col:lt(' + Math.abs(diff) + ')').remove();
            }
                
            if (($.browser.msie && document.documentMode == 8) || !$.browser.msie) {
                $('table', this.element)
                    .css('table-layout', 'fixed')
                    .css('table-layout', 'auto');
            }

            $('table .t-footer', this.element).attr('colspan', colspan);
        },

        bindGroup: function(dataItem, colspan, html, level) {
            var group = this.groups[level];
            var key = dataItem.Key;
            var column = $.grep(this.columns, function(column) { return group.member == column.member })[0];

            if (column && (column.format || column.type == 'Date'))
                key = $t.formatString(column.format || '{0:G}', key);

            html.cat('<tr class="t-grouping-row">')
                .rep('<td class="t-groupcell"></td>', level)
                .cat('<td colspan="')
                .cat(colspan - level)
                .cat('"><p class="t-reset"><a class="t-icon t-collapse" href="#"></a>')
                .cat(group.title)
                .cat(': ')
                .cat(key)
                .cat('</p></td></tr>');

            if (dataItem.HasSubgroups) {
                for (var i = 0, l = dataItem.Items.length; i < l; i++)
                    this.bindGroup(dataItem.Items[i], colspan, html, level + 1);
            } else {
                this.bindData(dataItem.Items, html, level + 1);
            }
        }
    }
})(jQuery);