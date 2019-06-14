import { Component } from '@angular/core';
import { TodosService } from 'backend';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ng-client-demo';

  constructor(private service: TodosService) { }

  ngOnInit() {
    this.service.get().subscribe(allTodos => {
      console.log(allTodos);
    })
  }
}
