import { Component, OnInit, Input } from '@angular/core';
import { IncomingDataService } from '../../../services/incoming-data.service';
import { Incoming } from '../../../interfaces/incoming';

@Component({
  selector: '[app-incoming-item]',
  templateUrl: './incoming-item.component.html',
  styleUrls: ['./incoming-item.component.scss'],
})
export class IncomingItemComponent implements OnInit {
  @Input() incoming: Incoming;
  constructor(private incomingDataService: IncomingDataService) {}

  ngOnInit(): void {}
}
