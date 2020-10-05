import React from 'react'
import { Layout, Aside, Header, Main } from './../components'

const Home = () => {
  return (
    <Layout aside={Aside} header={Header}>
      <Main />
    </Layout>
  )
}

export default Home
