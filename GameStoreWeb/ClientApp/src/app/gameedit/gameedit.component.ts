import { Component, OnInit, Inject } from '@angular/core';

import { ActivatedRoute } from '@angular/router';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Game } from "../home/home.component";

import { Router } from '@angular/router';



@Component({

    selector: 'app-gameedit',

    templateUrl: './gameedit.component.html',

    styleUrls: ['./gameedit.component.css']

})

export class GameeditComponent implements OnInit {

    game: Game;


    constructor(private route: ActivatedRoute, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) { }



    ngOnInit() {

        this.http.get<Game>(this.baseUrl + 'game/' + this.route.snapshot.params["id"]).subscribe(result => {

            this.game = result;

        }, error => console.error(error));

    }



    onUpdateGame() {

        const httpOptions = {

            headers: new HttpHeaders({

                'Content-Type': 'application/json'

            })

        };

        this.http.put<Game>(this.baseUrl + 'game/', this.game, httpOptions).subscribe(result => {

            console.log(result);

            this.router.navigate(['/']);

        }, error => console.error(error));

    }

    goBack() {
        this.router.navigate(['/']);
    }


}
