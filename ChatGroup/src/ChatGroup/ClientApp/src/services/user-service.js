import { UserManager } from 'oidc-client'

const settings = {
  authority: process.env.REACT_APP_OIDC_AUTHORITY,
  client_id: process.env.REACT_APP_OIDC_CLIENT_ID,
  redirect_uri: process.env.REACT_APP_OIDC_REDIRECT_URI,
  post_logout_redirect_uri: process.env.REACT_APP_OIDC_LOGOUT_REDIRECT_URI,
  response_type: process.env.REACT_APP_OIDC_RESPONSE_TYPE,
  scope: process.env.REACT_APP_OIDC_SCOPE,

  filterProtocolClaims: true,
  loadUserInfo: true
}

const userManager = new UserManager(settings)

export async function loadUserFromStorage() {
  try {
    return await userManager.getUser()
  } catch (e) {
    console.error(`User not found: ${e}`)
  }
}

export function signinRedirect() {
  return userManager.signinRedirect()
}

export function signinRedirectCallback() {
  return userManager.signinRedirectCallback()
}

export default userManager
