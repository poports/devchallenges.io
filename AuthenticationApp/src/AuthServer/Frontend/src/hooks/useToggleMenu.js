import { useState, useEffect } from 'react'

const useToggleMenu = (ref) => {
  const [invisible, setInvisible] = useState(true)

  const toggleMenu = () => {
    setInvisible(!invisible)
  }

  useEffect(() => {
    const listener = (event) => {
      if (!ref.current || ref.current.contains(event.target)) {
        return
      }
      setInvisible(true)
    }

    document.addEventListener('mousedown', listener)
    document.addEventListener('touchstart', listener)
    return () => {
      document.removeEventListener('mousedown', listener)
      document.removeEventListener('touchstart', listener)
    }
  }, [ref])

  return { invisible, toggleMenu }
}

export default useToggleMenu
