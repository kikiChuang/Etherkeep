import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Http, Response, Headers, RequestOptions} from '@angular/http';
import { Observable }     from 'rxjs/Observable';

import { HttpService } from './http.service';
import { AuthService } from './auth.service';
import { UserModel } from '../models/user.model';
import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';

@Injectable()
export class AccountService
{
	private baseUrl = 'http://localhost:5001/api';
	
	public constructor(private router: Router, private httpService: HttpService, private authService: AuthService) {}
	
	public username(model: LoginModel)
	{
		return this.httpService.post(this.baseUrl + '/account/username', {
			LoginMode: model.loginMode,
			CountryCallingCode: model.countryCallingCode,
			AreaCode: model.areaCode,
			SubscriberNumber: model.subscriberNumber,
			EmailAddress: model.emailAddress,
			Password: model.password
		}, {});
	};
	
	public register(model: RegisterModel)
	{
		return this.httpService.post(this.baseUrl + '/account/register', {
			RegisterMode: model.registerMode,
			CountryCallingCode: model.countryCallingCode,
			AreaCode: model.areaCode,
			SubscriberNumber: model.subscriberNumber,
			EmailAddress: model.emailAddress,
			Password: model.password,
			FirstName: model.firstName,
			LastName: model.lastName
		});
	}
	
	public getProfile()
	{
		return this.httpService.get(this.baseUrl + '/account/profile');
	}
}