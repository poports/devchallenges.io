import React from 'react'
import tw from 'twin.macro'

const Container = tw.div`grid grid-cols-default grid-rows-default h-screen`
const Header = tw.header`col-span-2 sm:col-start-2 row-start-1`
const SideBar = tw.div`row-span-3 row-start-1 sm:block hidden`
const Main = tw.div`col-span-2 sm:col-start-2 row-start-2`

const Layout = ({ aside, header, children }) => (
  <Container className="dark">
    <Header>{header()}</Header>
    <SideBar>{aside()}</SideBar>
    <Main>{children}</Main>
  </Container>
)

export default Layout
