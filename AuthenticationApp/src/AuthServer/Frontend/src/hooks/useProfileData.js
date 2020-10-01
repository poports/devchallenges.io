import { useContext, useState, useEffect } from 'react'
import { UserContext } from './../App'

const useProfileData = () => {
  const context = useContext(UserContext)

  const [user, setUser] = useState({
    name: '',
    token: '',
    authenticated: false
  })
  const [profileList, setProfileList] = useState([])

  useEffect(() => {
    setUser({
      name: context.user,
      token: context.token,
      authenticated: context.authenticated
    })

    const fetchProfile = async () => {
      if (!user.token) return
      const response = await fetch('/api/profile', {
        headers: !user.token ? {} : { Authorization: `Bearer ${user.token}` }
      })
      const data = await response.json()
      setProfileList(data)
    }

    fetchProfile()
  }, [context, user.token])

  return { user, profileList }
}

export default useProfileData
