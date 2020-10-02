import { UserManager, WebStorageStateStore } from 'oidc-client';
import { ApplicationPaths, ApplicationName } from './ApiAuthorizationConstants';

export class AuthorizeService {
	_callbacks = [];
	_nextSubscriptionId = 0;
	_user = null;
	_isAuthenticated = false;

	// By default pop ups are disabled because they don't work properly on Edge.
	// If you want to enable pop up authentication simply set this flag to false.
	_popUpDisabled = true;

	async isAuthenticated() {
		const user = await this.getUser();
		return !!user;
	}

	async getUser() {
		if (this._user && this._user.profile) {
			return this._user.profile;
		}

		await this.ensureUserManagerInitialized();
		const user = await this.userManager.getUser();
		return user && user.profile;
	}

	async getAccessToken() {
		await this.ensureUserManagerInitialized();
		const user = await this.userManager.getUser();
		return user && user.access_token;
	}

	async signIn(state) {
		await this.ensureUserManagerInitialized();
		try {
			await this.userManager.signinRedirect(
				this.createArguments(state)
			);
			return this.redirect();
		} catch (redirectError) {
			console.log(
				'Redirect authentication error: ',
				redirectError
			);
			return this.error(redirectError);
		}
	}

	async completeSignIn(url) {
		try {
			await this.ensureUserManagerInitialized();
			const user = await this.userManager.signinCallback(url);
			this.updateState(user);
			return this.success(user && user.state);
		} catch (error) {
			console.log('There was an error signing in: ', error);
			return this.error('There was an error signing in.');
		}
	}

	async signOut(state) {
		await this.ensureUserManagerInitialized();
		try {
			await this.userManager.signoutRedirect(
				this.createArguments(state)
			);
			return this.redirect();
		} catch (redirectSignOutError) {
			console.log('Redirect signout error: ', redirectSignOutError);
			return this.error(redirectSignOutError);
		}
	}

	async completeSignOut(url) {
		await this.ensureUserManagerInitialized();
		try {
			const response = await this.userManager.signoutCallback(url);
			this.updateState(null);
			return this.success(response && response.data);
		} catch (error) {
			console.log(`There was an error trying to log out '${error}'.`);
			return this.error(error);
		}
	}

	updateState(user) {
		this._user = user;
		this._isAuthenticated = !!this._user;
		this.notifySubscribers();
	}

	subscribe(callback) {
		this._callbacks.push({
			callback,
			subscription: this._nextSubscriptionId++,
		});
		return this._nextSubscriptionId - 1;
	}

	unsubscribe(subscriptionId) {
		const subscriptionIndex = this._callbacks
			.map((element, index) =>
				element.subscription === subscriptionId
					? { found: true, index }
					: { found: false }
			)
			.filter((element) => element.found === true);
		if (subscriptionIndex.length !== 1) {
			throw new Error(
				`Found an invalid number of subscriptions ${subscriptionIndex.length}`
			);
		}

		this._callbacks.splice(subscriptionIndex[0].index, 1);
	}

	notifySubscribers() {
		for (let i = 0; i < this._callbacks.length; i++) {
			const callback = this._callbacks[i].callback;
			callback();
		}
	}

	createArguments(state) {
		return { useReplaceToNavigate: true, data: state };
	}

	error(message) {
		return { status: AuthenticationResultStatus.Fail, message };
	}

	success(state) {
		return { status: AuthenticationResultStatus.Success, state };
	}

	redirect() {
		return { status: AuthenticationResultStatus.Redirect };
	}

	async ensureUserManagerInitialized() {
		if (this.userManager !== undefined) {
			return;
		}


		let settings = {
			authority: process.env.REACT_APP_OIDC_AUTHORITY,
			client_id: process.env.REACT_APP_OIDC_CLIENT_ID,
			redirect_uri: process.env.REACT_APP_OIDC_REDIRECT_URI,
			post_logout_redirect_uri: process.env.REACT_APP_OIDC_LOGOUT_REDIRECT_URI,
			response_type: process.env.REACT_APP_OIDC_RESPONSE_TYPE,
			scope: process.env.REACT_APP_OIDC_SCOPE
		}

		settings.automaticSilentRenew = false;
		settings.includeIdTokenInSilentRenew = false;
		settings.userStore = new WebStorageStateStore({
		    prefix: ApplicationName
		});
		//console.log(settings);
		this.userManager = new UserManager(settings);

		this.userManager.events.addUserSignedOut(async () => {
			await this.userManager.removeUser();
			this.updateState(undefined);
		});
	}

	static get instance() {
		return authService;
	}
}

const authService = new AuthorizeService();

export default authService;

export const AuthenticationResultStatus = {
	Redirect: 'redirect',
	Success: 'success',
	Fail: 'fail',
};
