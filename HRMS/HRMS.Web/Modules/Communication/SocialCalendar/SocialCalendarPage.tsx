import { Decorators, Widget, WidgetProps, serviceRequest } from '@serenity-is/corelib';
import { SocialPostRow, SocialPostService } from '../../ServerTypes/Communication';
import { SocialPostDialog } from '../SocialPost/SocialPostDialog';

@Decorators.registerClass('HRMS.Communication.SocialCalendarWidget')
export class SocialCalendarWidget extends Widget<any> {

    private currentYear: number;
    private currentMonth: number;
    private posts: SocialPostRow[] = [];

    constructor(props: WidgetProps<any>) {
        super(props);
        const now = new Date();
        this.currentYear = now.getFullYear();
        this.currentMonth = now.getMonth();
        this.loadPosts();
    }

    private loadPosts() {
        serviceRequest(SocialPostService.baseUrl + '/List', {}, (response: any) => {
            this.posts = response.Entities || [];
            this.renderCalendar();
        });
    }

    private renderCalendar() {
        const el = this.domNode;
        el.innerHTML = '';

        // Styles
        const style = document.createElement('style');
        style.textContent = `
            .social-calendar { font-family: 'Segoe UI', sans-serif; max-width: 1200px; margin: 0 auto; }
            .social-calendar .cal-header {
                display: flex; justify-content: space-between; align-items: center;
                padding: 16px 24px; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
                border-radius: 12px 12px 0 0; color: white;
            }
            .social-calendar .cal-header h2 { margin: 0; font-weight: 600; font-size: 1.3em; }
            .social-calendar .cal-header button {
                background: rgba(255,255,255,0.2); border: none; color: white; padding: 8px 16px;
                border-radius: 6px; cursor: pointer; font-size: 0.95em; transition: background 0.2s;
            }
            .social-calendar .cal-header button:hover { background: rgba(255,255,255,0.35); }
            .social-calendar .cal-grid {
                display: grid; grid-template-columns: repeat(7, 1fr);
                border: 1px solid #e0e0e0; border-top: none; border-radius: 0 0 12px 12px; overflow: hidden;
            }
            .social-calendar .cal-day-header {
                padding: 10px; text-align: center; font-weight: 600; font-size: 0.85em;
                background: #f5f5f5; color: #555; border-bottom: 1px solid #e0e0e0;
            }
            .social-calendar .cal-cell {
                min-height: 110px; padding: 6px; border: 1px solid #f0f0f0;
                cursor: pointer; transition: background 0.15s; position: relative;
            }
            .social-calendar .cal-cell:hover { background: #f8f5ff; }
            .social-calendar .cal-cell.other-month { background: #fafafa; color: #bbb; }
            .social-calendar .cal-cell .day-num {
                font-weight: 600; font-size: 0.85em; color: #333; margin-bottom: 4px;
            }
            .social-calendar .cal-cell.other-month .day-num { color: #ccc; }
            .social-calendar .cal-cell.today { background: #f0ebff; }
            .social-calendar .cal-cell.today .day-num { color: #667eea; }
            .social-calendar .cal-event {
                font-size: 0.72em; padding: 2px 6px; border-radius: 4px; margin-bottom: 2px;
                white-space: nowrap; overflow: hidden; text-overflow: ellipsis; cursor: pointer;
                color: white; font-weight: 500; transition: opacity 0.15s;
            }
            .social-calendar .cal-event:hover { opacity: 0.85; }
            .social-calendar .cal-event.draft { background: #9e9e9e; }
            .social-calendar .cal-event.scheduled { background: #2196f3; }
            .social-calendar .cal-event.published { background: #4caf50; }
            .social-calendar .cal-event.failed { background: #f44336; }
            .social-calendar .cal-legend {
                display: flex; gap: 16px; padding: 12px 24px; justify-content: center;
                flex-wrap: wrap;
            }
            .social-calendar .cal-legend-item {
                display: flex; align-items: center; gap: 6px; font-size: 0.8em; color: #666;
            }
            .social-calendar .cal-legend-dot {
                width: 10px; height: 10px; border-radius: 50%;
            }
        `;
        el.appendChild(style);

        const container = document.createElement('div');
        container.className = 'social-calendar';

        // Header
        const header = document.createElement('div');
        header.className = 'cal-header';

        const prevBtn = document.createElement('button');
        prevBtn.textContent = '\u2190 Previous';
        prevBtn.onclick = () => { this.currentMonth--; if (this.currentMonth < 0) { this.currentMonth = 11; this.currentYear--; } this.renderCalendar(); };

        const title = document.createElement('h2');
        const monthNames = ['January', 'February', 'March', 'April', 'May', 'June',
            'July', 'August', 'September', 'October', 'November', 'December'];
        title.textContent = `${monthNames[this.currentMonth]} ${this.currentYear}`;

        const nextBtn = document.createElement('button');
        nextBtn.textContent = 'Next \u2192';
        nextBtn.onclick = () => { this.currentMonth++; if (this.currentMonth > 11) { this.currentMonth = 0; this.currentYear++; } this.renderCalendar(); };

        header.appendChild(prevBtn);
        header.appendChild(title);
        header.appendChild(nextBtn);
        container.appendChild(header);

        // Grid
        const grid = document.createElement('div');
        grid.className = 'cal-grid';

        // Day headers
        const days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
        days.forEach(d => {
            const dh = document.createElement('div');
            dh.className = 'cal-day-header';
            dh.textContent = d;
            grid.appendChild(dh);
        });

        // Calendar cells
        const firstDay = new Date(this.currentYear, this.currentMonth, 1).getDay();
        const daysInMonth = new Date(this.currentYear, this.currentMonth + 1, 0).getDate();
        const daysInPrevMonth = new Date(this.currentYear, this.currentMonth, 0).getDate();
        const today = new Date();

        const totalCells = Math.ceil((firstDay + daysInMonth) / 7) * 7;

        for (let i = 0; i < totalCells; i++) {
            const cell = document.createElement('div');
            cell.className = 'cal-cell';

            let dayNum: number;
            let cellDate: Date;

            if (i < firstDay) {
                dayNum = daysInPrevMonth - firstDay + i + 1;
                cell.classList.add('other-month');
                cellDate = new Date(this.currentYear, this.currentMonth - 1, dayNum);
            } else if (i >= firstDay + daysInMonth) {
                dayNum = i - firstDay - daysInMonth + 1;
                cell.classList.add('other-month');
                cellDate = new Date(this.currentYear, this.currentMonth + 1, dayNum);
            } else {
                dayNum = i - firstDay + 1;
                cellDate = new Date(this.currentYear, this.currentMonth, dayNum);
                if (dayNum === today.getDate() && this.currentMonth === today.getMonth() && this.currentYear === today.getFullYear()) {
                    cell.classList.add('today');
                }
            }

            const dayNumEl = document.createElement('div');
            dayNumEl.className = 'day-num';
            dayNumEl.textContent = dayNum.toString();
            cell.appendChild(dayNumEl);

            // Add events for this day
            const cellDateStr = cellDate.toISOString().split('T')[0];
            const dayPosts = this.posts.filter(p => {
                const postDate = p.ScheduledDate || p.PublishedDate;
                if (!postDate) return false;
                return postDate.substring(0, 10) === cellDateStr;
            });

            dayPosts.forEach(post => {
                const event = document.createElement('div');
                event.className = 'cal-event';

                switch (post.Status) {
                    case 1: event.classList.add('draft'); break;
                    case 2: event.classList.add('scheduled'); break;
                    case 3: event.classList.add('published'); break;
                    case 4: event.classList.add('failed'); break;
                }

                let platformIcon = '\uD83D\uDCC4';
                switch ((post as any).SocialAccountPlatform) {
                    case 1: platformIcon = '\uD83D\uDCD8'; break;
                    case 2: platformIcon = '\uD83D\uDCF7'; break;
                    case 3: platformIcon = '\uD83D\uDCBC'; break;
                }

                event.textContent = `${platformIcon} ${post.Title || post.Content?.substring(0, 30) || 'Post'}`;
                event.title = `${post.Title || 'Post'}\nStatus: ${['', 'Draft', 'Scheduled', 'Published', 'Failed'][post.Status || 1]}`;

                event.onclick = (e) => {
                    e.stopPropagation();
                    this.openPostDialog(post.SocialPostId!);
                };

                cell.appendChild(event);
            });

            const capturedDate = new Date(cellDate);
            cell.onclick = () => {
                this.createPostForDate(capturedDate);
            };

            grid.appendChild(cell);
        }

        container.appendChild(grid);

        // Legend
        const legend = document.createElement('div');
        legend.className = 'cal-legend';
        const statuses = [
            { label: 'Draft', color: '#9e9e9e' },
            { label: 'Scheduled', color: '#2196f3' },
            { label: 'Published', color: '#4caf50' },
            { label: 'Failed', color: '#f44336' }
        ];
        statuses.forEach(s => {
            const item = document.createElement('span');
            item.className = 'cal-legend-item';
            item.innerHTML = `<span class="cal-legend-dot" style="background:${s.color}"></span> ${s.label}`;
            legend.appendChild(item);
        });
        container.appendChild(legend);

        el.appendChild(container);
    }

    private openPostDialog(postId: number) {
        const dlg = new SocialPostDialog({});
        dlg.loadByIdAndOpenDialog(postId);
        (dlg as any).dialogClose = () => {
            this.loadPosts();
        };
    }

    private createPostForDate(date: Date) {
        const dlg = new SocialPostDialog({});
        dlg.loadNewAndOpenDialog();
        setTimeout(() => {
            const dateStr = date.toISOString().split('T')[0];
            const scheduledInput = document.querySelector(`[id*="ScheduledDate"]`) as HTMLInputElement;
            if (scheduledInput) {
                scheduledInput.value = dateStr;
                scheduledInput.dispatchEvent(new Event('change'));
            }
        }, 300);
        (dlg as any).dialogClose = () => {
            this.loadPosts();
        };
    }
}

export default () => {
    const container = document.getElementById('GridDiv');
    if (container) {
        new SocialCalendarWidget({ element: container });
    }
};
