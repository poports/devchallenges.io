import React, { useState, useEffect, useContext } from 'react'

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
