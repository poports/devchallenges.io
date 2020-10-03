import React from 'react'
import useUserData from './../hooks/useUserData'
import tw, { styled } from 'twin.macro'
import { Link } from 'react-router-dom'

const Container = tw.div`container w-full justify-center flex flex-wrap mx-auto px-2 pt-8 lg:pt-16 mt-16`
const Section = tw.section`w-full lg:w-2/3`
const SectionHeadline = tw.h1`font-bold break-normal text-gray-700 px-2 text-xl mt-12 mb-0 lg:mt-0 md:text-2xl text-center`
const SectionDescription = tw.p`text-gray-700 mt-0 mb-12 px-2 text-sm tracking-tight text-center`

const Card = tw.div`py-8 mt-6 md:mt-0 md:rounded md:shadow md:bg-white md:rounded-lg`
const CardHeadline = tw.h2`mx-8 font-bold break-normal text-gray-700 px-2 text-lg mb-0 md:text-xl text-left`
const CardDescription = tw.p`mx-8 text-gray-700 mt-0 mb-12 px-2 text-sm tracking-tight`
const CardItem = tw.div`mx-8 lg:flex mb-6 lg:items-center lg:mr-12`
const CardItemLeft = tw.div`w-1/4`
const CardItemRight = tw.div`w-3/4`
const CardItemLabel = tw.span`text-gray-600 font-semibold md:text-left text-sm mb-3 md:mb-0 pr-4 uppercase`
const CardItemValue = tw.span`w-full px-4 h-10 rounded-lg`
const Line = tw.hr`bg-gray-300 my-4 border-0 h-px`
const Image = tw.img`h-16 w-16 rounded border-gray-500 mr-2 object-cover`

const StyledLink = tw(
  Link
)`no-underline hover:no-underline hover:bg-blue-400 focus:outline-none hover:text-white text-blue-500 py-2 px-8 rounded mr-8 shadow`

export default () => {
  const { profileList, photo } = useUserData()
  //console.log(profileList)

  return (
    <Container>
      <Section>
        <SectionHeadline>PersonalInfo</SectionHeadline>
        <SectionDescription>
          Basic info, like your name and photo
        </SectionDescription>
        <Card>
          <div tw="w-full flex justify-between items-center">
            <div>
              <CardHeadline>Profile</CardHeadline>
              <CardDescription>
                Changes will be reflected to every services
              </CardDescription>
            </div>
            <div>
              <StyledLink to="/authentication/profile">Edit</StyledLink>
            </div>
          </div>

          <Line />
          <CardItem>
            <CardItemLeft>
              <CardItemLabel>Photo</CardItemLabel>
            </CardItemLeft>
            <CardItemRight>
              <CardItemValue>
                <Image src={photo} alt="Profile picture" />
              </CardItemValue>
            </CardItemRight>
          </CardItem>
          <Line />

          {profileList.map((item, index) => (
            <div key={index}>
              <CardItem>
                <CardItemLeft>
                  <CardItemLabel>{item.name}</CardItemLabel>
                </CardItemLeft>
                <CardItemRight>
                  <CardItemValue>
                    {item.value ? item.value : '[not set]'}
                  </CardItemValue>
                </CardItemRight>
              </CardItem>
              <Line />
            </div>
          ))}
        </Card>
      </Section>
    </Container>
  )
}
