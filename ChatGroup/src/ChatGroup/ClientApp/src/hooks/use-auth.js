import React, { useState, useEffect, useContext, createContext } from 'react'
import { UserManager } from 'oidc-client'

// Log.logger = console
// Log.level = Log.DEBUG

const config = {
  authority: process.env.REACT_APP_OIDC_AUTHORITY,
  client_id: process.env.REACT_APP_OIDC_CLIENT_ID,
  redirect_uri: process.env.REACT_APP_OIDC_REDIRECT_URI,
  post_logout_redirect_uri: process.env.REACT_APP_OIDC_LOGOUT_REDIRECT_URI,
  response_type: process.env.REACT_APP_OIDC_RESPONSE_TYPE,
  scope: process.env.REACT_APP_OIDC_SCOPE,
  filterProtocolClaims: true,
  loadUserInfo: true
  // automaticSilentRenew: false,
}

const userManager = new UserManager(config)
const authContext = createContext()

export const ProvideAuth = ({ children }) => {
  const auth = useProvideAuth()
  return <authContext.Provider value={auth}>{children}</authContext.Provider>
}

export const useAuth = () => {
  return useContext(authContext)
}

export const signin = async () => {
  await userManager.signinRedirect()
}

export const signinCallback = async () => {
  try {
    await userManager.signinCallback()
  } catch (e) {
    console.error(`Callback error: ${e}`)
  }
}

const useProvideAuth = () => {
  const [user, setUser] = useState(null)

  const loadUserFromStorage = async () => {
    try {
      let result = await userManager.getUser()
      console.log('got user', user)
      if (result) {
        setUser(result)
      } else {
        setUser(false)
      }
    } catch (e) {
      console.error(`User not found: ${e}`)
    }
  }
  loadUserFromStorage()

  // useEffect(() => {
  //   const loadUserFromStorage = async () => {
  //     try {
  //       let result = await userManager.getUser()
  //       console.log('got user', user)
  //       if (result) {
  //         setUser(result)
  //       } else {
  //         setUser(false)
  //       }
  //     } catch (e) {
  //       console.error(`User not found: ${e}`)
  //     }
  //   }
  //   loadUserFromStorage()
  //   //return () => unsubscribe()
  // })

  return {
    user
  }
}
