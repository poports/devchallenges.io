import { useState, useEffect, useContext } from 'react'
import { UserContext } from './../App'

const useAuth = () => {
  const context = useContext(UserContext)

  const [user, setUser] = useState({
    name: null,
    token: null,
    authenticated: false
  })

  useEffect(() => {
    setUser({
      name: context.user,
      token: context.token,
      authenticated: context.isAuthenticated
    })
  }, [context])

  return { user }
}

export default useAuth
